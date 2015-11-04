using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

/// TODO:
/// Edge bug
/// Adding balls (MAX BALLS)
/// StartGame blocks destroy bug
/// Ball paddle intersecting bug
/// Ball at shallow angles doesn't reflect correctly
/// STARTNEW
/// UPDATE
/// BALL MOVE
/// BALL COLLIDESWITH

namespace Breakout
{
    public partial class frmGame : Form
    {
        // form constructor
        public frmGame()
        {
            InitializeComponent();
        }

        // when the form loads, position the text labels for the relevant mode, and start a new game
        private void frmGame_Load(object sender, EventArgs e)
        {
            this.KeyDown += (object o, KeyEventArgs k) => { InputManager.KeyDown(k); }; // keydown event handler passes parameters to InputManager
            this.KeyUp += (object o, KeyEventArgs k) => { InputManager.KeyUp(k); }; // keyup event handler does the same thing
            Game.LabelLevels = lblLevels;
            Game.LabelLives1 = lblLives;
            lblLevels.Location = new Point((int)(this.Size.Width * 0.5f - lblLevels.Size.Width * 0.5f), (int)((float)this.Size.Height * 0.95f) - (int)((float)lblLevels.Size.Height * 0.5f)); // move levels completed label to bottom centre
            lblLives.Location = new Point(200, (int)((float)this.Size.Height * 0.95f) - (int)((float)lblLives.Size.Height * 0.5f)); // move lives label to bottom left
            lblPoints.Location = new Point(this.Size.Width - 200 - lblPoints.Size.Width, (int)((float)this.Size.Height * 0.95f) - (int)((float)lblPoints.Size.Height * 0.5f)); // move points label to bottom right
            if (Game.CurrentMode != GameMode.Versus) // not versus mode, so  points label is left alone
            {
                Game.LabelPoints = lblPoints;
            }
            else // versus mode, so points label is new second player lives label
            {
                Game.LabelLives2 = lblPoints;
            }

            // reset player lives
            Game.LivesPlayer1 = Game.DefaultLives;
            Game.LivesPlayer2 = Game.DefaultLives;

            Game.Points = 0; // reset points
            Game.LevelsCompleted = 0; // reset levels completed
            Game.StartNew(this); // start first game
        }
    }

    // The game module - runs the game
    public static class Game
    {
        public static List<Ball> Balls; // all the balls in the game
        public static List<Block> Blocks; // all the blocks in the game

        public const int DefaultLives = 3; // the beginning number of lives a player has
        public static int LivesPlayer1 = 3; // the number of lives player 1 has
        public static int LivesPlayer2 = 3; // the number of lives player 2 has
        public static int Points = 0; // the number of points the player(s) has
        public static int LevelsCompleted = 0; // the number of levels completed
        public static int BallsInPlay = 0; // the number of balls in the game
        public static int SleepTime = 15; // the number of milliseconds between each frame/iteration of the game loop
        public static Player LastPlayerHit = Player.Player1; // the last player that hit the ball
        public static Player LastPlayerLost = Player.Player1; // the last player who  the ball

        // game settings
        public static float SpeedIncrease = 0.0f; // the increase in speed every second by a ball chosen by the player
        public const float DefaultSpeedIncrease = 0.0f; // the increase in speed every second by a ball by default
        public static float MaxSpeed = 3.0f; // the max speed a ball can reach chosen by the player
        public const float DefaultMaxSpeed = 3.0f; // the max speed a ball can reach by default
        public static float StartSpeed = 0.7f; // the initial speed of a ball chosen by the player
        public const float DefaultStartSpeed = 0.7f; // the initial speed of a ball by default
        public static float PaddleSpeed = 1.0f; // the speed a paddle moves with chosen by the player
        public const float DefaultPaddleSpeed = 1.0f; // the speed a paddle moves with by default
        public static int BlockRows = 6; // the number of rows in the block grid chosen by the player
        public const int DefaultBlockRows = 6; // the number of rows in the block grid by default
        public static int BlockColumns = 10; // the number of columns in the block grid chosen by the player
        public const int DefaultBlockColumns = 10; // the number of columns in the block grid by default
        public static int MaxBalls = 1; // the highest number of balls you can have at once chosen by the player
        public const int DefaultMaxBalls = 1; // the highest number of balls you can have at once by default

        public static bool LeftMovement1 = false; // whether ot not player 1 is trying to move left
        public static bool RightMovement1 = false; // whether or not player 1 is trying to move right
        public static bool LeftMovement2 = false; // whether or not player 2 is trying to move left
        public static bool RightMovement2 = false; // whether or not player 2 is trying to move right
        public static bool InPlay = false; // whether or not the game is being played

        public static Label LabelPoints; // the label which displays the number of points of the player(s)
        public static Label LabelLives1; // the label which displays the number of lives of player 1
        public static Label LabelLives2; // the label which displays the number of lives of player 2
        public static Label LabelLevels; // the label which displays the number of levels completed

        public static Paddle PaddleObject1; // player 1's paddle object
        public static Paddle PaddleObject2; // player 2's paddle object

        public static Vector FormSize; // the size of the form in vector form

        public static GameMode CurrentMode = GameMode.Classic; // the game mode the game is in

        private static Thread gameThread; // the thread the game is being run in
        private static Form currentForm; // the form the game is using to be played in

        /// <summary>
        /// sets up and begins new round
        /// </summary>
        /// <param name="form">the form being used for the game</param>
        public static void StartNew(Form form)
        {
            LeftMovement1 = false;
            RightMovement1 = false;
            LeftMovement2 = false;
            RightMovement2 = false;
            LastPlayerHit = Player.Player1;
            LabelLevels.Text = "Levels Completed: " + LevelsCompleted.ToString();
            UpdateScores();
            Balls = new List<Ball>();
            Blocks = new List<Block>();
            FormSize = new Vector(form.Size.Width, form.Size.Height - 100);
            PictureBox paddle1 = new PictureBox();
            form.Controls.Add(paddle1);
            if (CurrentMode == GameMode.Coop || CurrentMode == GameMode.Versus) // 2 player
            {
                PictureBox paddle2 = new PictureBox();
                form.Controls.Add(paddle2);
                PaddleObject2 = new Paddle(paddle2, new Vector(FormSize.X * 0.75f, FormSize.Y));
                PaddleObject1 = new Paddle(paddle1, new Vector(FormSize.X * 0.25f, FormSize.Y));
            }
            else // 1 player
            {
                PaddleObject1 = new Paddle(paddle1, new Vector(FormSize.X * 0.5f, FormSize.Y));
                PaddleObject2 = null;
            }
            currentForm = form;
            BallsInPlay = 0;
            AddBall();
            int blockRows = ((CurrentMode == GameMode.Classic) ? DefaultBlockRows : BlockRows);
            int blockColumns = ((CurrentMode == GameMode.Classic) ? DefaultBlockColumns : BlockColumns);
            int blockWidth = (int)FormSize.X / blockColumns;
            int blockHeight = (int)FormSize.Y / 3 / blockRows;
            const int blockFrame = 4;
            for (int x = 0; x < blockColumns; x++)
            {
                for (int y = 0; y < blockRows; y++)
                {
                    float rowPercentage = (float)y / (float)blockRows;
                    PictureBox newPictureBox = new PictureBox();
                    newPictureBox.BackColor = Color.FromArgb((int)Math.Round(255 * Math.Max(0, 1 - rowPercentage * 2), 0), (int)Math.Round(255 * (1 - 2 * Math.Abs(0.5f - rowPercentage)), 0), (int)Math.Round(255 * Math.Max(0, rowPercentage * 2 - 1), 0));
                    currentForm.Controls.Add(newPictureBox);
                    Vector newBlockPosition = new Vector(x * blockWidth + blockFrame * 0.5f, y * blockHeight + blockFrame * 0.5f);
                    Vector newBlockSize = new Vector(blockWidth - blockFrame, blockHeight - blockFrame);
                    Block newBlock = new Block(newPictureBox, newBlockPosition, newBlockSize);
                    newBlock.Points = 50 + 50 * (blockRows - y);
                }
            }
            gameThread = new Thread(GameThread);
            gameThread.IsBackground = true;
            gameThread.Start();
            form.Disposed += delegate { gameThread.Abort(); };
            InPlay = true;
        }

        /// <summary>
        /// finishes the current round and opens the end form
        /// </summary>
        /// <param name="playerLost">which player lost the game (for versus mode)</param>
        public static void FinishGame(Player playerLost)
        {
            FinishCurrent(); // finish the current round
            if (CurrentMode == GameMode.Versus) // versus, so show who won
            {
                if (playerLost == Player.Player1) // player 1 lost
                {
                    frmEnd FrmEnd = new frmEnd(0, "Player 2 Wins", currentForm); // player 2 wins
                    FrmEnd.Show();
                }
                else if (playerLost == Player.Player2) // player 2 lost
                {
                    frmEnd FrmEnd = new frmEnd(0, "Player 1 Wins", currentForm); // player 1 wins
                    FrmEnd.Show();
                }
            }
            else // not versus, so show the score
            {
                frmEnd FrmEnd = new frmEnd(Points, "Score: " + Points.ToString(), currentForm);
                FrmEnd.Show();
            }
        }

        // finish the current round
        public static void FinishCurrent()
        {
            InPlay = false; // stop the game
            gameThread.Abort(); // stop the game thread

            // remove all the blocks
            foreach (Block block in Blocks)
            {
                currentForm.Controls.Remove(block.PictureBox);
            }

            // remove all the balls
            foreach (Ball ball in Balls)
            {
                currentForm.Controls.Remove(ball.PictureBox);
            }

            // remove the paddles
            currentForm.Controls.Remove(PaddleObject1.PictureBox);
            if (PaddleObject2 != null)
                currentForm.Controls.Remove(PaddleObject2.PictureBox);
        }

        /// <summary>
        /// destroys a block and allocates points
        /// </summary>
        /// <param name="block">the block being destroyed</param>
        public static void DestroyBlock(Block block)
        {
            if (InPlay) // can only destroy in the game
            {
                currentForm.Controls.Remove(block.PictureBox); // remove picturebox
                Blocks.Remove(block); // remove from block list

                // if there are more balls to add, add one
                if (BallsInPlay < MaxBalls)
                    AddBall();

                // give the number of points the block is worth
                if (CurrentMode != GameMode.Versus)
                    Points += block.Points;

                UpdateScores(); // display the new points

                // if all the blocks have been destroyed, start a new game
                if (Blocks.Count <= 0)
                {
                    FinishCurrent();
                    System.Threading.Thread.Sleep(1000);
                    LevelsCompleted++;
                    StartNew(currentForm);
                }
            }
        }

        /// <summary>
        /// destroy a ball and take a life
        /// </summary>
        /// <param name="ball">the ball being destroyed</param>
        public static void DestroyBall(Ball ball)
        {
            currentForm.Controls.Remove(ball.PictureBox); // remove picturebox from the form
            ball.PictureBox.Dispose(); // release all the resources being used by the picturebox
            BallsInPlay--; // there is 1 less ball in play

            // 2 players with their own lives, so calculate which player lost the life
            if (CurrentMode == GameMode.Versus)
            {
                // the ball hit the bottom in the left half, player 1 loses a life
                if (ball.Position.X + ball.Size.X * 0.5f <= FormSize.X * 0.5f)
                {
                    LivesPlayer1 -= 1;
                    LastPlayerLost = Player.Player1;
                    UpdateScores();

                    // finish the game if it was player 1's last life
                    if (LivesPlayer1 <= 0)
                    {
                        FinishGame(Player.Player1);
                    }

                    // otherwise replace the ball
                    else
                    {
                        AddBall();
                    }
                }

                // the ball hit the bottom in the right half, player 2
                else
                {
                    LivesPlayer2 -= 1;
                    LastPlayerLost = Player.Player2;
                    UpdateScores();

                    // finish the game if it was player 2's last life
                    if (LivesPlayer2 <= 0)
                    {
                        FinishGame(Player.Player2);
                    }

                    // otherwise replace the ball
                    else
                    {
                        AddBall();
                    }
                }
            }

            // ball is destroyed, life is lost
            else
            {
                LivesPlayer1 -= 1;
                UpdateScores(); // display the new lives

                // finish the game if the was the last life
                if (LivesPlayer1 <= 0)
                {
                    FinishGame(0);
                }

                // otherwise replace the ball
                else
                {
                    AddBall();
                }
            }
        }

        // create a new ball
        public static void AddBall()
        {
            PictureBox newPictureBox = new PictureBox(); // create a picturebox for the ball
            newPictureBox.BackColor = Color.White; // ball is white
            newPictureBox.Size = new Size(50, 50); // 50x50 pixels in size
            currentForm.Controls.Add(newPictureBox); // ad picturebox to form
            BallsInPlay++; // another ball is in play
            Ball ball = new Ball(newPictureBox, new Vector(0, ((CurrentMode == GameMode.Classic) ? DefaultStartSpeed : StartSpeed))); // create the ball as a game object
        }

        // updates the player points and lives text labels to display the correct values
        public static void UpdateScores()
        {
            if (CurrentMode != GameMode.Versus) // not versus mode, so lives and points labels
            {
                LabelPoints.Text = "Points: " + Points.ToString();
                LabelLives1.Text = "Lives: " + LivesPlayer1.ToString();
            }
            else // versus mode, so 2 sets of lives
            {
                LabelLives1.Text = "Lives: " + LivesPlayer1.ToString();
                LabelLives2.Text = "Lives: " + LivesPlayer2.ToString();
            }
        }

        delegate void delegateUpdate(int timeElapsed); // delegate is required to invoke the update subroutine, and access form controls from a thread separate to the main worker UI thread

        static void Update(int timeElapsed) // do game iteration stuff here
        {
            float secondsElapsed = timeElapsed * 0.001f; // the number of seconds since the last iteration

            // calculate paddle 1 movement
            Vector position1 = PaddleObject1.Position;
            float xCoordinateChange1 = 0;
            float paddleSpeed = ((Game.CurrentMode == GameMode.Classic) ? Game.DefaultPaddleSpeed : Game.PaddleSpeed);
            if (LeftMovement1 && !RightMovement1)
            {
                xCoordinateChange1 = -paddleSpeed;
            }
            else if (!LeftMovement1 && RightMovement1)
            {
                xCoordinateChange1 = paddleSpeed;
            }
            float lastXCoordinate1 = position1.X;
            float newX1 = position1.X + (int)Math.Round(xCoordinateChange1 * timeElapsed);

            // calculate paddle 2 movement
            if (PaddleObject2 != null)
            {
                Vector position2 = PaddleObject2.Position;
                float xCoordinateChange2 = 0;
                if (LeftMovement2 && !RightMovement2)
                {
                    xCoordinateChange2 = -paddleSpeed;
                }
                else if (!LeftMovement2 && RightMovement2)
                {
                    xCoordinateChange2 = paddleSpeed;
                }
                float lastXCoordinate2 = position2.X;
                float newX2 = position2.X + (int)Math.Round(xCoordinateChange2 * timeElapsed);
                if (newX2 < FormSize.X * 0.5f)
                    newX2 = FormSize.X * 0.5f;
                if (newX2 + PaddleObject2.Size.X > FormSize.X)
                    newX2 = FormSize.X - PaddleObject2.Size.X;
                PaddleObject2.Speed = (newX2 - lastXCoordinate2) / timeElapsed;
                PaddleObject2.Position = new Vector(newX2, position2.Y);
                if (newX1 < 0)
                    newX1 = 0;
                if (newX1 + PaddleObject1.Size.X > FormSize.X * 0.5f)
                    newX1 = FormSize.X * 0.5f - PaddleObject1.Size.X;
                PaddleObject1.Speed = (newX1 - lastXCoordinate1) / timeElapsed;
                PaddleObject1.Position = new Vector(newX1, position1.Y);
            }
            else
            {
                if (newX1 < 0)
                    newX1 = 0;
                if (newX1 + PaddleObject1.Size.X > FormSize.X)
                    newX1 = FormSize.X - PaddleObject1.Size.X;
                PaddleObject1.Speed = (newX1 - lastXCoordinate1) / timeElapsed;
                PaddleObject1.Position = new Vector(newX1, position1.Y);
            }
            // MOVE BALL
            UpdateScores();
            try
            {
                foreach (Ball ball in Game.Balls)
                {
                    if (!ball.PictureBox.IsDisposed)
                    {
                        ball.Speed += ((CurrentMode == GameMode.Classic) ? DefaultSpeedIncrease : SpeedIncrease) * secondsElapsed;
                        ball.StartMove(secondsElapsed);
                    }
                }
            }
            catch
            {
            }
        }

        // the subroutine which runs the game thread
        static void GameThread()
        {
            Stopwatch stopwatch = new Stopwatch(); // timer to wait 15 milliseconds
            while (InPlay)
            {
                Thread.Sleep(Game.SleepTime); // wait 15 milliseconds
                stopwatch.Stop();
                int timeElapsed = stopwatch.Elapsed.Milliseconds;
                stopwatch.Reset();
                stopwatch.Start();
                try
                {
                    if (timeElapsed != 0) // if not the same frame
                        currentForm.Invoke(new delegateUpdate(Update), timeElapsed); // run the game update subroutine
                }
                catch
                {
                }
            }
        }

        // closes the form and opens a menu form
        public static void CloseForm()
        {
            currentForm.Close();
            new frmMenu().Show();

        }
    }

    // Handles key input - acts as an interface/view-controller between the form class and the game class: KeyDown and KeyUp events in the form class call these functions, and passes the key codes through, and changes the relevant variables in the game class
    public static class InputManager
    {

        // The key codes for player controls
        private static Keys LeftKey1 = Keys.Left;
        private static Keys RightKey1 = Keys.Right;
        private static Keys LeftKey2 = Keys.A;
        private static Keys RightKey2 = Keys.D;

        /// <summary>
        /// handles keys being pressed
        /// </summary>
        /// <param name="e">the key event parameter from the event handler in the frmGame class</param>
        public static void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == LeftKey1)
            {
                Game.LeftMovement1 = true;
            }
            else if (e.KeyCode == RightKey1)
            {
                Game.RightMovement1 = true;
            }
            else if (e.KeyCode == LeftKey2)
            {
                Game.LeftMovement2 = true;
            }
            else if (e.KeyCode == RightKey2)
            {
                Game.RightMovement2 = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Game.CloseForm();
            }
        }

        /// <summary>
        /// handles keys being released
        /// </summary>
        /// <param name="e">the key event parameter from the event handler in the frmGame class</param>
        public static void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == LeftKey1)
            {
                Game.LeftMovement1 = false;
            }
            else if (e.KeyCode == RightKey1)
            {
                Game.RightMovement1 = false;
            }
            else if (e.KeyCode == LeftKey2)
            {
                Game.LeftMovement2 = false;
            }
            else if (e.KeyCode == RightKey2)
            {
                Game.RightMovement2 = false;
            }
        }
    }

    // base class for all moving game objects
    public class Box
    {
        // these act effectively as enumerations for edges
        public int TopEdge = 0;
        public int RightEdge = 1;
        public int BottomEdge = 2;
        public int LeftEdge = 3;

        public PictureBox PictureBox; // every game object is represented graphically in the form by its own picturebox
        public Vector Position // the position of the game object in vector form
        {
            get // returns the picturebox location in vector form
            {
                return new Vector(PictureBox.Location.X, PictureBox.Location.Y);
            }
            set // moves the picturebox to match its vector value when changed
            {
                PictureBox.Location = new Point((int)Math.Round(value.X, 0), (int)Math.Round(value.Y, 0));
            }
        }
        public Vector Size // the size of the game object in vector form
        {
            get // returns the picturebox size in vector form
            {
                return new Vector(PictureBox.Size.Width, PictureBox.Size.Height);
            }
            set // resizes the picturebox to match its vector value when changed
            {
                PictureBox.Size = new Size((int)Math.Round(value.X, 0), (int)Math.Round(value.Y, 0));
            }
        }

        /// <summary>
        /// calculates whether or not 2 boxes intersect using the AABB bounding boxes method
        /// </summary>
        /// <param name="position1">the vector position of the first box</param>
        /// <param name="size1">the vector size of the first box</param>
        /// <param name="position2">the vector position of the second box</param>
        /// <param name="size2">the vector size of the second box</param>
        /// <returns>whether the boxes intersect of not</returns>
        public static bool Intersects(Vector position1, Vector size1, Vector position2, Vector size2)
        {
            return (position1.X + size1.X >= position2.X && position1.X <= position2.X + size2.X && position1.Y + size1.Y >= position2.Y && position1.Y <= position2.Y + size2.Y);
        }
    }

    // class for ball game object
    public class Ball : Box
    {
        public Vector Velocity; // the speed and direction of the ball in vector form
        public float Speed // the speed of the ball
        {
            get // returns the magnitude of the ball velocity, limited to the bal max speed
            {
                return Math.Min(((Game.CurrentMode == GameMode.Classic) ? Game.DefaultMaxSpeed : Game.MaxSpeed), (float)Math.Pow((float)(Math.Pow(Velocity.X, 2) + (float)Math.Pow(Velocity.Y, 2)), 0.5));
            }
            set // changes the velocity to match the speed
            {
                float l = value / Speed;
                Velocity.X *= l;
                Velocity.Y *= l;
            }
        }

        // class constructor, requires a picturebox and a starting velocity
        public Ball(PictureBox picture, Vector velocity)
        {
            this.PictureBox = picture;
            this.Velocity = velocity;

            // the game is in a 2 player mode, and player 2 lost the ball, so player 2 gets the new ball
            if ((Game.CurrentMode == GameMode.Coop || Game.CurrentMode == GameMode.Versus) && Game.LastPlayerLost == Player.Player2)
            {
                this.Position = new Vector(Game.PaddleObject2.Position.X + Game.PaddleObject2.Size.X * 0.5f - Size.X * 0.5f, Game.PaddleObject2.Position.Y - Size.Y);
                Game.LastPlayerHit = Player.Player2; // player 2 starts with the ball
            }

            // otherwise player1 gets the ball
            else
            {
                this.Position = new Vector(Game.PaddleObject1.Position.X + Game.PaddleObject1.Size.X * 0.5f - Size.X * 0.5f, Game.PaddleObject1.Position.Y - Size.Y);//new Vector(Game.FormSize.X * 0.5f - Size.X * 0.5f, Game.FormSize.Y * 0.5f - Size.Y * 0.5f);
                Game.LastPlayerHit = Player.Player1; // player 1 starts with the new ball
            }
            Game.Balls.Add(this);
        }

        /// <summary>
        /// calculates collisions between the ball and a block, and finds the block surface tha was hit
        /// </summary>
        /// <param name="block">the block being hit</param>
        /// <param name="newPosition">the position the ball has</param>
        /// <param name="newVelocity">the velocity the ball is trying to move with</param>
        /// <param name="collidedRays">a list of rayIDs which have already collided with a surface</param>
        /// <returns>the position, length and surface of the collision</returns>
        public CollisionReturn CollidesWithBlock(Block block, Vector newPosition, Vector newVelocity, List<int> collidedRays)
        {
            // vector rays of moving ball
            Ray[] Vectors = new Ray[4];
            Vectors[TopEdge] = new Ray(newPosition, newVelocity);
            Vectors[RightEdge] = new Ray(Vector.Add(newPosition, new Vector(Size.X, 0)), newVelocity);
            Vectors[BottomEdge] = new Ray(Vector.Add(newPosition, new Vector(0, Size.Y)), newVelocity);
            Vectors[LeftEdge] = new Ray(Vector.Add(newPosition, new Vector(Size.X, Size.Y)), newVelocity);

            CollisionReturn collisionReturn = new CollisionReturn(false);

            int rayID = 0;
            foreach (Ray ray in Vectors)
            {
                int edgeID = 0;
                if (!collidedRays.Contains(rayID)) // if the ray being used hasn't already collided with a box
                {
                    // check every edge of the block
                    foreach (Ray edge in block.Edges)
                    {
                        RaycastReturn raycastReturn = Ray.Raycast(ray, edge); // see if the ray meets the edge
                        if (raycastReturn.Intersects)
                        {
                            // if there has already been a collision, check for a shorter one
                            if (collisionReturn.Intersects)
                            {
                                if (raycastReturn.length < collisionReturn.length) // if the ball velocity ray hits this edge before any other ray hits an edge
                                {
                                    collisionReturn = new CollisionReturn(raycastReturn);
                                    collisionReturn.Edge = edgeID;
                                    collisionReturn.Ray = rayID;
                                }
                            }

                            // haven't had a ray collision yet, so use this collision by default
                            else
                            {
                                collisionReturn = new CollisionReturn(raycastReturn);
                                collisionReturn.Edge = edgeID;
                                collisionReturn.Ray = rayID;
                            }
                        }
                        edgeID++; // check next edge
                    }
                }
                rayID++; // check next ray
            }
            return collisionReturn; // return results
        }

        /// <summary>
        /// calculates collisions between the ball and a paddle, and finds the paddle surface that was hit
        /// </summary>
        /// <param name="paddle">the paddle that is being hit</param>
        /// <param name="newPosition">the position the ball has</param>
        /// <param name="newVelocity">the velocity the ball is trying to move with</param>
        /// <returns>the position, length and surface of the collision</returns>
        public CollisionReturn CollidesWithPaddle(Paddle paddle, Vector newPosition, Vector newVelocity)
        {
            Ray[] Vectors = new Ray[4]; // vector rays of moving ball
            Vectors[TopEdge] = new Ray(newPosition, newVelocity);
            Vectors[RightEdge] = new Ray(Vector.Add(newPosition, new Vector(Size.X, 0)), newVelocity);
            Vectors[BottomEdge] = new Ray(Vector.Add(newPosition, new Vector(0, Size.Y)), newVelocity);
            Vectors[LeftEdge] = new Ray(Vector.Add(newPosition, new Vector(Size.X, Size.Y)), newVelocity);

            CollisionReturn collisionReturn = new CollisionReturn(false);

            foreach (Ray ray in Vectors)
            {
                int edgeID = 0;
                foreach (Ray edge in paddle.Edges)
                {
                    RaycastReturn raycastReturn = Ray.Raycast(ray, edge);
                    if (raycastReturn.Intersects)
                    {
                        if (collisionReturn.Intersects)
                        {
                            if (raycastReturn.length < collisionReturn.length)
                            {
                                collisionReturn = new CollisionReturn(raycastReturn);
                                collisionReturn.Edge = edgeID;
                            }
                        }
                        else
                        {
                            collisionReturn = new CollisionReturn(raycastReturn);
                            collisionReturn.Edge = edgeID;
                        }
                    }
                    edgeID++;
                }
            }
            return collisionReturn;
        }

        /// <summary>
        /// starts to move the ball for its next move
        /// </summary>
        /// <param name="timeElapsed">the amount of time passed since last move</param>
        public void StartMove(float timeElapsed)
        {
            if (Game.InPlay)
                Move(Velocity, timeElapsed); // begin move
        }

        /// <summary>
        /// try to move the ball. Handles block, paddle and wall collisions
        /// </summary>
        /// <param name="newVelocity">the velocity the ball is trying to move with</param>
        /// <param name="timeElapsed">the time since the last move</param>
        private void Move(Vector newVelocity, float timeElapsed)
        {
            Vector positionChange = Vector.Mul(newVelocity, timeElapsed * 1000);
            Vector position = this.Position;
            Vector size = this.Size;
            Vector newPosition = Vector.Add(position, positionChange);

            List<Block> blocksHit = new List<Block>();
            List<int> collidedRays = new List<int>();

            bool reflectedX = false;
            bool reflectedY = false;

            foreach (Block block in Game.Blocks)
            {
                if (Box.Intersects(block.Position, block.Size, newPosition, size))
                {
                    //blockHit = true;

                    // IMPORTANT --
                    // Each Vector ray of ball in collideswith algorithms SHOULD only be collided with once.
                    // More than once can result in blocks being destroyed that shouldn't!!!

                    CollisionReturn collisionBlockReturn = CollidesWithBlock(block, position, positionChange, collidedRays);
                    if (collisionBlockReturn.Intersects) // hits a block
                    {
                        if ((collisionBlockReturn.Edge == 0 || collisionBlockReturn.Edge == 2) && !reflectedY) // Y
                        {
                            newVelocity.Y *= -1;
                            reflectedY = true;
                        }
                        if ((collisionBlockReturn.Edge == 1 || collisionBlockReturn.Edge == 3) && !reflectedX) // X
                        {
                            newVelocity.X *= -1;
                            reflectedX = true;
                        }
                        this.Velocity = newVelocity;
                        blocksHit.Add(block);
                        collidedRays.Add(collisionBlockReturn.Ray);
                    }
                }
            }
            foreach (Block block in blocksHit)
            {
                Game.DestroyBlock(block);
            }
            if (blocksHit.Count <= 0)
            {
                if (Box.Intersects(Game.PaddleObject1.Position, Game.PaddleObject1.Size, newPosition, size))
                {
                    CollisionReturn collisionPaddleReturn = CollidesWithPaddle(Game.PaddleObject1, position, positionChange);
                    //System.Console.WriteLine(collisionPaddleReturn.Intersects + ", " + collisionPaddleReturn.length + ", " + collisionPaddleReturn.Edge);
                    if (collisionPaddleReturn.Intersects) // hits paddle
                    {
                        Game.LastPlayerHit = Player.Player1;
                        // ID EDGE IS 0 THEN ADD SPIN + ANGLE
                        if (collisionPaddleReturn.Edge == 0 || collisionPaddleReturn.Edge == 2) // Y
                        {
                            newVelocity.Y *= -1;
                            float speed = this.Speed;
                            float currentAngle = Angles.CartesianToPolar(newVelocity);
                            float newAngle = (position.X + size.X * 0.5f - Game.PaddleObject1.Position.X - Game.PaddleObject1.Size.X * 0.5f) / 175 * 90 + Game.PaddleObject1.Speed * 30; // left - negative angle, right - positive angle
                            newAngle += Angles.Deg(currentAngle);
                            while (newAngle < 0)
                            {
                                newAngle += 360;
                            }
                            if (newAngle < 180)
                            {
                                newAngle = Math.Min(newAngle, 85);
                            }
                            else
                            {
                                newAngle = Math.Max(newAngle, 275);
                            }
                            Vector newDirection = Angles.PolarToCartesian(Angles.Rad(newAngle));
                            newVelocity = Vector.Mul(newDirection, speed);
                            //newVelocity = new Vector((float)Math.Round(newVelocity.X, 0), (float)Math.Round(newVelocity.Y, 0));
                        }
                        else // X - 1 || 3
                        {
                            // 2 different edges have raycast at same distance, therefore wrong edge can be chosen when ball hits very edge
                            newVelocity.X *= -1;
                        }
                        this.Velocity = newVelocity;
                        Move(newVelocity, timeElapsed);
                    }
                }
                else if (Game.PaddleObject2 != null && Box.Intersects(Game.PaddleObject2.Position, Game.PaddleObject2.Size, newPosition, size))
                {
                    CollisionReturn collisionPaddleReturn = CollidesWithPaddle(Game.PaddleObject2, position, positionChange);
                    //System.Console.WriteLine(collisionPaddleReturn.Intersects + ", " + collisionPaddleReturn.length + ", " + collisionPaddleReturn.Edge);
                    if (collisionPaddleReturn.Intersects) // hits paddle
                    {
                        Game.LastPlayerHit = Player.Player2;
                        // ID EDGE IS 0 THEN ADD SPIN + ANGLE
                        if (collisionPaddleReturn.Edge == 0 || collisionPaddleReturn.Edge == 2) // Y
                        {
                            newVelocity.Y *= -1;
                            float speed = this.Speed;
                            float currentAngle = Angles.CartesianToPolar(newVelocity);
                            float newAngle = (position.X + size.X * 0.5f - Game.PaddleObject2.Position.X - Game.PaddleObject2.Size.X * 0.5f) / 175 * 90 + Game.PaddleObject2.Speed * 30; // left - negative angle, right - positive angle
                            newAngle += Angles.Deg(currentAngle);
                            while (newAngle < 0)
                            {
                                newAngle += 360;
                            }
                            if (newAngle < 180)
                            {
                                newAngle = Math.Min(newAngle, 85);
                            }
                            else
                            {
                                newAngle = Math.Max(newAngle, 275);
                            }
                            Vector newDirection = Angles.PolarToCartesian(Angles.Rad(newAngle));
                            newVelocity = Vector.Mul(newDirection, speed);
                            //newVelocity = new Vector((float)Math.Round(newVelocity.X, 0), (float)Math.Round(newVelocity.Y, 0));
                        }
                        else // X - 1 || 3
                        {
                            // 2 different edges have raycast at same distance, therefore wrong edge can be chosen when ball hits very edge
                            newVelocity.X *= -1;
                        }
                        this.Velocity = newVelocity;
                        Move(newVelocity, timeElapsed);
                    }
                }
                else // check walls
                {
                    bool velocityChanged = false;
                    bool ballDestroyed = false;
                    if (newPosition.X < 0)
                    {
                        newVelocity.X *= -1;
                        velocityChanged = true;
                    }
                    if (newPosition.X + size.X > Game.FormSize.X)
                    {
                        newVelocity.X *= -1;
                        velocityChanged = true;
                    }
                    if (newPosition.Y < 0)
                    {
                        newVelocity.Y *= -1;
                        velocityChanged = true;
                    }
                    if (newPosition.Y + size.Y > Game.FormSize.Y)
                    {
                        Game.DestroyBall(this);
                        ballDestroyed = true;
                    }
                    if (!ballDestroyed)
                    {
                        if (velocityChanged)
                        {
                            this.Velocity = newVelocity;
                            Move(newVelocity, timeElapsed);
                        }
                        else
                        {
                            this.Position = newPosition;
                        }
                    }
                }
            }
            else
            {
                Move(newVelocity, timeElapsed);
            }
        }
    }

    // class for block game objects
    public class Block : Box
    {
        public readonly Ray[] Edges = new Ray[4]; // rays representing the 4 edges of the box
        public int Points; // how many points the block awards when destroyed

        // class constructor. A block will not move, so I can set the edges at creation, assuming they will never move
        public Block(PictureBox picture, Vector position, Vector size)
        {
            PictureBox = picture;
            Position = position;
            Size = size;
            Edges[TopEdge] = new Ray(position, new Vector(Size.X, 0)); // top edge
            Edges[RightEdge] = new Ray(Vector.Add(position, new Vector(Size.X, 0)), new Vector(0, Size.Y)); // right edge
            Edges[BottomEdge] = new Ray(Vector.Add(position, new Vector(0, Size.Y)), new Vector(Size.X, 0)); // bottom edge
            Edges[LeftEdge] = new Ray(position, new Vector(0, Size.Y)); // left edge
            Game.Blocks.Add(this);
        }
    }

    // class for paddle game objects
    public class Paddle : Box
    {
        private Ray[] edges = new Ray[4]; // privately stored box edges to be used internally, as it should only be set by CalculateEdges()
        public Ray[] Edges // edges property to be accessed externally
        {
            get
            { // can only get, as it should never be set externally. Unlike the block, the paddle moves, so there needs to be a way to recalculate the edges at any moment
                CalculateEdges(); // recalculates the edges when called upon
                return edges;
            }
        }
        public float Speed = 0; // the speed of the paddle

        // class constructor, needs a picturebox and a starting position. The edges are not calculated as they are not needed at the start, and can still be used later
        public Paddle(PictureBox pictureBox, Vector position)
        {
            PictureBox = pictureBox;
            PictureBox.BackColor = Color.DodgerBlue;
            PictureBox.Size = new Size(150, 25);
            Position = new Vector(position.X - Size.X * 0.5f, position.Y - Size.Y);
        }

        /// <summary>
        /// finds the rays for the edges at a specific moment
        /// </summary>
        private void CalculateEdges()
        {
            Vector position = Position;
            Vector size = Size;
            edges[TopEdge] = new Ray(position, new Vector(size.X, 0)); // top edge
            edges[RightEdge] = new Ray(Vector.Add(position, new Vector(size.X, 0)), new Vector(0, size.Y)); // right edge
            edges[BottomEdge] = new Ray(Vector.Add(position, new Vector(0, size.Y)), new Vector(size.X, 0)); // bottom edge
            edges[LeftEdge] = new Ray(position, new Vector(0, size.Y)); // left edge
        }
    }

    // similar to the 'Point' class, but with x, y and some helper methods
    public class Vector
    {
        public float X; // the x coordinate
        public float Y; // the y coordinate

        // class constructor for an empty vector
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
        }

        // class constructor for a vector with 
        public Vector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// to simplify adding 2 vectors together
        /// </summary>
        /// <param name="vector1">the first vector being added</param>
        /// <param name="vector2">the second vector being added</param>
        /// <returns>the composition of the 2 vectors</returns>
        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        /// <summary>
        /// to simplify multiplying a vector by a scale factor
        /// </summary>
        /// <param name="vector">the vector being multiplied</param>
        /// <param name="alpha">the scale factor to multiply it with</param>
        /// <returns>the product of the vector and the scale factor</returns>
        public static Vector Mul(Vector vector, float alpha)
        {
            return new Vector(vector.X * alpha, vector.Y * alpha);
        }
    }

    // a vector with a direction and length. This class also handles ray collision/raycasting
    public class Ray
    {
        public Vector Position; // form coordinates of the ray
        public Vector Direction; // the vector direction (not unit) of the ray
        public float Length // the length of the ray - can get or set (changes the direction vector too) the value
        {
            get // return direction vector magnitude
            {
                return (float)Math.Pow((float)(Math.Pow(Direction.X, 2) + (float)Math.Pow(Direction.Y, 2)), 0.5);
            }
            set // change direction vector magnitude to match new length
            {
                float l = value / Length;
                Direction.X *= l;
                Direction.Y *= l;
            }
        }

        // empty ray class constructor
        public Ray()
        {
            this.Position = new Vector();
            this.Direction = new Vector();
        }

        // class constructor with position and direction
        public Ray(Vector position, Vector direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        // class constructor for length if unit direction vector is given
        public Ray(Vector position, Vector direction, float length)
        {
            this.Position = position;
            this.Direction = direction;
            this.Length = length;
        }

        /// <summary>
        /// will check for collisions between 2 rays and return the results
        /// </summary>
        /// <param name="ray1">the first ray in the collision</param>
        /// <param name="ray2">the second ray in the collision</param>
        /// <returns>the position and length of the raycast collision</returns>
        public static RaycastReturn Raycast(Ray ray1, Ray ray2)
        {

            // shorten the variable names
            float x1 = ray1.Position.X;
            float y1 = ray1.Position.Y;
            float a1 = ray1.Direction.X;
            float b1 = ray1.Direction.Y;
            float x2 = ray2.Position.X;
            float y2 = ray2.Position.Y;
            float a2 = ray2.Direction.X;
            float b2 = ray2.Direction.Y;

            if (a1 * b2 == a2 * b1) // parallel, so won't collide
            {
                return new RaycastReturn(false); // rays don't collide, so return false collision
            }
            else // they collide at some point, given their lengths are infinite
            {
                float i = (x2 * b2 + a2 * y1 - a2 * y2 - x1 * b2) / (a1 * b2 - a2 * b1); // distance between start and collision along ray1
                Vector position = new Vector(x1 + i * a1, y1 + i * b1); // form coordinates of collision
                if (i > 1 || i < 0) // outside length of ray1
                {
                    return new RaycastReturn(false); // do not meet each other, so return false collision
                }
                else // they collide within their lengths
                {
                    float length = i * ray1.Length; // length of ray1 up to collision
                    return new RaycastReturn(true, position, length); // return true collision
                }
            }
        }
    }

    // container for data returned by a raycast operation
    public class RaycastReturn
    {
        public Boolean Intersects; // whether or not the rays collide
        public Vector Position; // the form coordinates of where they collide
        public float length; // the length of the first ray up to the collision

        // empty class constructor
        public RaycastReturn() { }

        // class constructor for simply true or false raycast collisions (mainly false)
        public RaycastReturn(bool intersects)
        {
            this.Intersects = intersects;
        }

        // detailed class constructor for (true) raycast collisions
        public RaycastReturn(bool intersects, Vector position, float length)
        {
            this.Intersects = intersects;
            this.Position = position;
            this.length = length;
        }
    }

    // a container for data returned by a box collision
    public class CollisionReturn : RaycastReturn
    {
        public int Edge; // the edgeID hit of the box that was hit
        public int Ray; // the rayID that hit the box

        // class constructor for simply true or false box collision (mainly false)
        public CollisionReturn(bool intersects)
            : base(intersects)
        {
            this.Intersects = intersects;
        }

        // class constructor for a box collision from a raycast edge collision
        public CollisionReturn(RaycastReturn raycastReturn)
        {
            Intersects = raycastReturn.Intersects;
            Position = raycastReturn.Position;
            length = raycastReturn.length;
        }
    }

    // module to help converting angles between degrees and radians, and coordinates from between polar and cartesian
    public static class Angles
    {

        /// <summary>
        /// converts a cartesian form vector to a polar form angle
        /// </summary>
        /// <param name="direction">the direction vector being converted</param>
        /// <returns>the polar form angle</returns>
        public static float CartesianToPolar(Vector direction)
        {
            if (direction.X == 0 && direction.Y == 0) // has no direction, so return angle of 0
            {
                return 0;
            }
            else
            {
                return (float)Math.Atan2((double)direction.X, -(double)direction.Y);
            }
        }

        /// <summary>
        /// converts a polar form angle to a cartesian form unit vector
        /// </summary>
        /// <param name="angle">the angle being converted</param>
        /// <returns>the converted unit vector</returns>
        public static Vector PolarToCartesian(float angle)
        {
            return new Vector((float)Math.Sin((double)angle), -(float)Math.Cos((double)angle));
        }

        /// <summary>
        /// converts an angle from degrees to radians
        /// </summary>
        /// <param name="angleDegrees">the angle in degrees</param>
        /// <returns>the angle in radians</returns>
        public static float Rad(float angleDegrees)
        {
            return angleDegrees / 180 * (float)Math.PI;
        }

        /// <summary>
        /// converts an angle from radians to degrees
        /// </summary>
        /// <param name="angleRadians">the angle in radians</param>
        /// <returns>the angle in degrees</returns>
        public static float Deg(float angleRadians)
        {
            return angleRadians * 180 / (float)Math.PI;
        }
    }

    // enumeration for the Game Mode, more readable code than using 0 1, 2, 3
    public enum GameMode
    {
        Classic,
        Custom,
        Coop,
        Versus
    }

    // enumeration for the Player
    public enum Player
    {
        Player1,
        Player2
    }

    // networking class handles data transfer to and from the web database
    public static class Networking
    {
        /// <summary>
        /// Tries to get a list of highscores from the database
        /// </summary>
        /// <returns>the list of highscores</returns>
        public static List<HighScore> GetResults()
        {
            List<HighScore> results = new List<HighScore>(); // a list to store the highscores
            WebRequest webrequest = WebRequest.Create("http://mgray.site88.net/get.php"); // create a request 
            webrequest.Timeout = 5000; // stop trying after 5 seconds
            using (WebResponse webresponse = webrequest.GetResponse()) // send request
            {
                using (Stream stream = webresponse.GetResponseStream())
                {
                    using (StreamReader streamreader = new StreamReader(stream))
                    {
                        string response = streamreader.ReadToEnd(); // get JSON encoded results
                        try
                        {
                            JArray json = (JArray)JsonConvert.DeserializeObject(response); // create .NET object from JSON list
                            foreach (var i in json)
                            {
                                results.Add(new HighScore() { ID = (int)i[0], Name = (string)i[1], Score = (int)i[2], Date = (string)i[3] }); // add result
                            }
                        }
                        catch // problem converting JSON to .NET objects
                        {
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Tries to upload a score to the database
        /// </summary>
        /// <param name="name">the name of the player</param>
        /// <param name="score">the player's score</param>
        /// <param name="date">the date the score was achieved</param>
        /// <returns>a string describing the result of the attempt</returns>
        public static void SendResult(string name, int score, string date)
        {
            string postData = "Name=" + name + "&Score=" + score.ToString() + "&Date=" + date;
            byte[] data = new ASCIIEncoding().GetBytes(postData); // get array of bytes to stream

            WebRequest webrequest = WebRequest.Create("http://mgray.site88.net/add.php");
            webrequest.Method = "POST";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.ContentLength = data.Length;
            webrequest.Timeout = 50000;
            try
            {
                using (Stream requestStream = webrequest.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length); // stream data to php file
                }
            }
            catch
            {
            }
        }
    }

    // highscore container to be used in lists
    public struct HighScore
    {
        public int ID;
        public string Name;
        public int Score;
        public string Date;
    }
}

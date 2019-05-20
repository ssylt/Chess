﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Schack {

    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont arial;

        Random rnd = new Random();


        public static King wk;
        public static King bk;

        public static Queen wQ;
        public static Queen bQ;
        public static Queen wQ2;
        public static Queen bQ2;

        public static Rook wR1;
        public static Rook wR2;
        public static Rook bR1;
        public static Rook bR2;

        public static Bishop wB;
        public static Bishop wB2;
        public static Bishop bB;
        public static Bishop bB2;

        public static Knight wh;
        public static Knight wh2;
        public static Knight bh;
        public static Knight bh2;


        public static WhitePawn wp1;
        public static WhitePawn wp2;
        public static WhitePawn wp3;
        public static WhitePawn wp4;
        public static WhitePawn wp5;
        public static WhitePawn wp6;
        public static WhitePawn wp7;
        public static WhitePawn wp8;

        public static BlackPawn bp1;
        public static BlackPawn bp2;
        public static BlackPawn bp3;
        public static BlackPawn bp4;
        public static BlackPawn bp5;
        public static BlackPawn bp6;
        public static BlackPawn bp7;
        public static BlackPawn bp8;

        public static SoundEffect placingPiece;

        
        Core core = new Core();

        public static List<Rectangle> boardList = new List<Rectangle>();
        public static List<Piece> activePiece = new List<Piece>();
        public static List<Piece> checkPieces = new List<Piece>();
        public static Dictionary<int, bool> isTaken = new Dictionary<int, bool>();
        public static Piece[] isWho = new Piece[64];
        List<string> isTakenString = new List<string>();
        public static bool exitGame = false;
        public static int runda = 0;
        public static bool newRound = true;

        public static bool[] shackArray = new bool[64];

        public static MouseState mus = Mouse.GetState();
        public static MouseState gammalMus = Mouse.GetState();
        KeyboardState tangentBord = Keyboard.GetState(); //för highscores senare

        Texture2D bakgrundsbild, wb, wH, wkImg, wpImg, wr, bkImg, red, menyBak, playKnapp, settings, debug, back, exit, disableDebug, whitewins, blackwins, newGame, chessGray;
        Piece isHolding;


        //Meny Hitboxes --------------------------------------------------------

        // Rectangle wqHitbox = new Rectangle(87, 87, 87, 87);

        // Rectangle wbHitbox = new Rectangle(87*2, 87, 87, 87);

        //King hitbox
        Rectangle bkHitbox = new Rectangle(87 * 4, 0, 87, 87);
        Rectangle wkHitbox = new Rectangle(87 * 4, 87 * 7, 87, 87);

        //White pawn hitboxes
        Rectangle wpHitbox1 = new Rectangle(87 * 0, 87 * 6, 87, 87);
        Rectangle wpHitbox2 = new Rectangle(87 * 1, 87 * 6, 87, 87);
        Rectangle wpHitbox3 = new Rectangle(87 * 2, 87 * 6, 87, 87);
        Rectangle wpHitbox4 = new Rectangle(87 * 3, 87 * 6, 87, 87);
        Rectangle wpHitbox5 = new Rectangle(87 * 4, 87 * 6, 87, 87);
        Rectangle wpHitbox6 = new Rectangle(87 * 5, 87 * 6, 87, 87);
        Rectangle wpHitbox7 = new Rectangle(87 * 6, 87 * 6, 87, 87);
        Rectangle wpHitbox8 = new Rectangle(87 * 7, 87 * 6, 87, 87);

        //Black pawn hitboxes
        Rectangle bpHitbox1 = new Rectangle(87 * 0, 87 * 1, 87, 87);
        Rectangle bpHitbox2 = new Rectangle(87 * 1, 87 * 1, 87, 87);
        Rectangle bpHitbox3 = new Rectangle(87 * 2, 87 * 1, 87, 87);
        Rectangle bpHitbox4 = new Rectangle(87 * 3, 87 * 1, 87, 87);
        Rectangle bpHitbox5 = new Rectangle(87 * 4, 87 * 1, 87, 87);
        Rectangle bpHitbox6 = new Rectangle(87 * 5, 87 * 1, 87, 87);
        Rectangle bpHitbox7 = new Rectangle(87 * 6, 87 * 1, 87, 87);
        Rectangle bpHitbox8 = new Rectangle(87 * 7, 87 * 1, 87, 87);

        //White rook hitboxes
        Rectangle wR1Hitbox = new Rectangle(87 * 0, 87 * 7, 87, 87);
        Rectangle wR2Hitbox = new Rectangle(87 * 7, 87 * 7, 87, 87);

        //Black rook hitboxes
        Rectangle bR1Hitbox = new Rectangle(87 * 0, 87 * 0, 87, 87);
        Rectangle bR2Hitbox = new Rectangle(87 * 7, 87 * 0, 87, 87);

        Rectangle wrHitbox = new Rectangle(87 * 6, 87, 87, 87);
        Rectangle musHitbox = new Rectangle(0, 0, 9, 9);
        //Queen Hitbox
        Rectangle wQHitbox = new Rectangle(87 * 3, 87 * 7, 87, 87);
        Rectangle bQHitbox = new Rectangle(87 * 3, 0, 87, 87);
        Rectangle wQ2Hitbox = new Rectangle(87 * 88, 87 * 77, 87, 87);
        Rectangle bQ2Hitbox = new Rectangle(87 * 88, 77, 87, 87);

        //Bishops
        Rectangle wBHitbox = new Rectangle(87 * 2, 87 * 7, 87, 87);
        Rectangle wBHitbox2 = new Rectangle(87 * 5, 87 * 7, 87, 87);
        Rectangle bBHitbox = new Rectangle(87 * 2, 87 * 0, 87, 87);
        Rectangle bBHitbox2 = new Rectangle(87 * 5, 87 * 0, 87, 87);

        //Horse hitbox
        Rectangle whHitbox = new Rectangle(87 * 1, 87 * 7, 87, 87);
        Rectangle whHitbox2 = new Rectangle(87 * 6, 87 * 7, 87, 87);
        Rectangle bhHitbox = new Rectangle(87 * 1, 87 * 0, 87, 87);
        Rectangle bhHitbox2 = new Rectangle(87 * 6, 87 * 0, 87, 87);

        //vecktor2
        public static Vector2 tempPos;


        public static int scen = 1;
        public static int menuScene = 0;

        public static string text = "";
        public static List<string> debugger = new List<string>();
        public static string text2 = "";

        public static bool debuggingMode = false;
        public static bool mouseIsHolding = false;
        public static bool shackMatt = false;
        public static bool vitVinst = false;
        public static bool blackCheck = false;
        public static bool whiteCheck = false;
        public static Piece theChecker;
        string checkText = "";


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 696 + 87 * 4;
            graphics.PreferredBackBufferHeight = 696;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            core.ui.AddBoard(boardList);


            base.Initialize();
        }
        protected override void LoadContent()//load
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bakgrundsbild = Content.Load<Texture2D>("portablejim_2D_Chess_set_-_Chessboard_1");

            for (int i = 0; i < 8 * 8; i++) {
                isTakenString.Add(" ");
                if (i >= 0 && i <= 15 || i >= 48 && i <= 63) {
                    isTaken[i] = true;
                } else {
                    isTaken[i] = false;
                }

            }
            Load();
        }

        protected override void UnloadContent() {
            //inget
        }
        
        protected override void Update(GameTime gameTime)                                                                                       //update !!!!!!!!!!!!!!
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseUpdate();
            if (exitGame) {
                Exit();
            }
            
            if (runda % 2 != 0) {
                if (newRound) {
                    for (int i = 0; i < activePiece.Count; i++) {
                        activePiece[i].checkArray = new bool[64];
                        if (!(activePiece[i] is King) && !activePiece[i].isDead) {
                            activePiece[i].CheckPath(core.getPos(activePiece[i]));
                        }
                    }
                    newRound = false;
                }
                bk.SchackMatt();
            } else if (runda % 2 == 0) {
                if (newRound) {
                    for (int i = 0; i < activePiece.Count; i++) {
                        activePiece[i].checkArray = new bool[64];
                        if (!(activePiece[i] is King) && !activePiece[i].isDead) {
                            activePiece[i].CheckPath(core.getPos(activePiece[i]));
                        }
                    }
                    newRound = false;
                }
                wk.SchackMatt();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (scen) {
                case 0:
                    DrawGame();
                    break;
                case 1:
                    DrawMenu();
                    break;
            }
        }
        private void Load() {
            bool[] tmp = new bool[64];
            //Kings
            wk = new King(Content.Load<Texture2D>("wk"), wkHitbox, new Vector2(87 * 4, 87 * 7), new Vector2(87 * 4, 87 * 7), true, tmp, tmp, false, 0, tmp);
            bk = new King(Content.Load<Texture2D>("bk"), bkHitbox, new Vector2(87 * 4, 0), new Vector2(87 * 4, 0), false, tmp, tmp, false, 0, tmp);

            //Queens
            wQ = new Queen(Content.Load<Texture2D>("wq"), wQHitbox, new Vector2(87 * 3, 87 * 7), new Vector2(87 * 3, 87 * 7), true, tmp, tmp, false, 0, tmp);
            bQ = new Queen(Content.Load<Texture2D>("bq"), bQHitbox, new Vector2(87 * 3, 0), new Vector2(87 * 3, 0), false, tmp, tmp, false, 0, tmp);
            wQ2 = new Queen(Content.Load<Texture2D>("wq"), wQ2Hitbox, new Vector2(87 * 88, 87 * 99), new Vector2(87 * 88, 87 * 99), true, tmp, tmp, false, 0, tmp);
            bQ2 = new Queen(Content.Load<Texture2D>("bq"), bQ2Hitbox, new Vector2(87 * 88, 88), new Vector2(87 * 88, 88), false, tmp, tmp, false, 0, tmp);

            //White rooks
            wR1 = new Rook(Content.Load<Texture2D>("wr"), wR1Hitbox, new Vector2(87 * 0, 87 * 0), new Vector2(87 * 0, 87 * 7), true, tmp, tmp, false, 0, tmp);
            wR2 = new Rook(Content.Load<Texture2D>("wr"), wR2Hitbox, new Vector2(87 * 7, 87 * 0), new Vector2(87 * 7, 87 * 7), true, tmp, tmp, false, 0, tmp);

            //Black rooks
            bR1 = new Rook(Content.Load<Texture2D>("br"), bR1Hitbox, new Vector2(87 * 0, 87 * 0), new Vector2(87 * 0, 87 * 0), false, tmp, tmp, false, 0, tmp);
            bR2 = new Rook(Content.Load<Texture2D>("br"), bR2Hitbox, new Vector2(87 * 7, 87 * 0), new Vector2(87 * 7, 87 * 0), false, tmp, tmp, false, 0, tmp);

            //White Pawns
            wp1 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox1, new Vector2(87 * 0, 87 * 6), new Vector2(87 * 0, 87 * 6), true, tmp, tmp, false, 0, tmp);
            wp2 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox2, new Vector2(87 * 1, 87 * 6), new Vector2(87 * 1, 87 * 6), true, tmp, tmp, false, 0, tmp);
            wp3 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox3, new Vector2(87 * 2, 87 * 6), new Vector2(87 * 2, 87 * 6), true, tmp, tmp, false, 0, tmp);
            wp4 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox4, new Vector2(87 * 3, 87 * 6), new Vector2(87 * 3, 87 * 6), true, tmp, tmp, false, 0, tmp);
            wp5 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox5, new Vector2(87 * 4, 87 * 6), new Vector2(87 * 4, 87 * 6), true, tmp, tmp, false, 0, tmp);
            wp6 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox6, new Vector2(87 * 5, 87 * 6), new Vector2(87 * 5, 87 * 6), true, tmp, tmp, false, 0, tmp);
            wp7 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox7, new Vector2(87 * 6, 87 * 6), new Vector2(87 * 6, 87 * 6), true, tmp, tmp, false, 0, tmp);
            wp8 = new WhitePawn(Content.Load<Texture2D>("wp"), wpHitbox8, new Vector2(87 * 7, 87 * 6), new Vector2(87 * 7, 87 * 6), true, tmp, tmp, false, 0, tmp);

            //Black Pawns
            bp1 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox1, new Vector2(87 * 0, 87 * 1), new Vector2(87 * 0, 87 * 1), false, tmp, tmp, false, 0, tmp);
            bp2 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox2, new Vector2(87 * 1, 87 * 1), new Vector2(87 * 1, 87 * 1), false, tmp, tmp, false, 0, tmp);
            bp3 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox3, new Vector2(87 * 2, 87 * 1), new Vector2(87 * 2, 87 * 1), false, tmp, tmp, false, 0, tmp);
            bp4 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox4, new Vector2(87 * 3, 87 * 1), new Vector2(87 * 3, 87 * 1), false, tmp, tmp, false, 0, tmp);
            bp5 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox5, new Vector2(87 * 4, 87 * 1), new Vector2(87 * 4, 87 * 1), false, tmp, tmp, false, 0, tmp);
            bp6 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox6, new Vector2(87 * 5, 87 * 1), new Vector2(87 * 5, 87 * 1), false, tmp, tmp, false, 0, tmp);
            bp7 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox7, new Vector2(87 * 6, 87 * 1), new Vector2(87 * 6, 87 * 1), false, tmp, tmp, false, 0, tmp);
            bp8 = new BlackPawn(Content.Load<Texture2D>("bp"), bpHitbox8, new Vector2(87 * 7, 87 * 1), new Vector2(87 * 7, 87 * 1), false, tmp, tmp, false, 0, tmp);

            //Bishops
            wB = new Bishop(Content.Load<Texture2D>("wb"), wBHitbox, new Vector2(87 * 2, 87 * 7), new Vector2(87 * 2, 87 * 7), true, tmp, tmp, false, 0, tmp);
            wB2 = new Bishop(Content.Load<Texture2D>("wb"), wBHitbox2, new Vector2(87 * 5, 87 * 7), new Vector2(87 * 5, 87 * 7), true, tmp, tmp, false, 0, tmp);
            bB = new Bishop(Content.Load<Texture2D>("bb"), bBHitbox, new Vector2(87 * 2, 87 * 0), new Vector2(87 * 2, 87 * 0), false, tmp, tmp, false, 0, tmp);
            bB2 = new Bishop(Content.Load<Texture2D>("bb"), bBHitbox2, new Vector2(87 * 5, 87 * 0), new Vector2(87 * 5, 87 * 0), false, tmp, tmp, false, 0, tmp);

            //Knights (Horses)
            wh = new Knight(Content.Load<Texture2D>("wh"), whHitbox, new Vector2(87 * 1, 87 * 7), new Vector2(87 * 1, 87 * 7), true, tmp, tmp, false, 0, tmp);
            wh2 = new Knight(Content.Load<Texture2D>("wh"), whHitbox2, new Vector2(87 * 6, 87 * 7), new Vector2(87 * 6, 87 * 7), true, tmp, tmp, false, 0, tmp);
            bh = new Knight(Content.Load<Texture2D>("bh"), bhHitbox, new Vector2(87 * 1, 87 * 0), new Vector2(87 * 1, 87 * 0), false, tmp, tmp, false, 0, tmp);
            bh2 = new Knight(Content.Load<Texture2D>("bh"), bhHitbox2, new Vector2(87 * 6, 87 * 0), new Vector2(87 * 6, 87 * 0), false, tmp, tmp, false, 0, tmp);

            //-----------------------------------------------------------------

            //Queens add
            activePiece.Add(wQ);
            activePiece.Add(bQ);

            //White Pawns add
            activePiece.Add(wp1);
            activePiece.Add(wp2);
            activePiece.Add(wp3);
            activePiece.Add(wp4);
            activePiece.Add(wp5);
            activePiece.Add(wp6);
            activePiece.Add(wp7);
            activePiece.Add(wp8);

            //Black Pawns add
            activePiece.Add(bp1);
            activePiece.Add(bp2);
            activePiece.Add(bp3);
            activePiece.Add(bp4);
            activePiece.Add(bp5);
            activePiece.Add(bp6);
            activePiece.Add(bp7);
            activePiece.Add(bp8);

            //Bishops add
            activePiece.Add(wB2);
            activePiece.Add(wB);
            activePiece.Add(bB);
            activePiece.Add(bB2);

            //Rooks add
            activePiece.Add(wR1);
            activePiece.Add(wR2);
            activePiece.Add(bR1);
            activePiece.Add(bR2);

            //Knights add
            activePiece.Add(wh);
            activePiece.Add(wh2);
            activePiece.Add(bh);
            activePiece.Add(bh2);

            //Kings add
            activePiece.Add(wk);
            activePiece.Add(bk);


            //Load img -----------------------------------------------------------------
            wb = Content.Load<Texture2D>("wb");
            red = Content.Load<Texture2D>("red");
            wH = Content.Load<Texture2D>("wh");
            wkImg = Content.Load<Texture2D>("wk");
            wpImg = Content.Load<Texture2D>("wp");
            wr = Content.Load<Texture2D>("wr");
            bkImg = Content.Load<Texture2D>("bk");
            menyBak = Content.Load<Texture2D>("menyBak");
            playKnapp = Content.Load<Texture2D>("Play");
            arial = Content.Load<SpriteFont>("arial");
            settings = Content.Load<Texture2D>("settings");
            debug = Content.Load<Texture2D>("debugging");
            back = Content.Load<Texture2D>("back");
            exit = Content.Load<Texture2D>("exit");
            disableDebug = Content.Load<Texture2D>("disableDebugging");
            whitewins = Content.Load<Texture2D>("whitewins");
            blackwins = Content.Load<Texture2D>("blackwins");
            placingPiece = Content.Load<SoundEffect>("chessmove");
            newGame = Content.Load<Texture2D>("newgame");
            chessGray = Content.Load<Texture2D>("chessgray");
            //isWho -----------------------------------------------------------------
            isWho[0] = bR1;
            isWho[1] = bh;
            isWho[2] = bB;
            isWho[3] = bQ;
            isWho[4] = bk;
            isWho[5] = bB2;
            isWho[6] = bh2;
            isWho[7] = bR2;

            isWho[8] = bp1;
            isWho[9] = bp2;
            isWho[10] = bp3;
            isWho[11] = bp4;
            isWho[12] = bp5;
            isWho[13] = bp6;
            isWho[14] = bp7;
            isWho[15] = bp8;

            isWho[48] = wp1;
            isWho[49] = wp2;
            isWho[50] = wp3;
            isWho[51] = wp4;
            isWho[52] = wp5;
            isWho[53] = wp6;
            isWho[54] = wp7;
            isWho[55] = wp8;

            isWho[56] = wR1;
            isWho[57] = wh;
            isWho[58] = wB;
            isWho[59] = wQ;
            isWho[60] = wk;
            isWho[61] = wB2;
            isWho[62] = wh2;
            isWho[63] = wR2;

        }
        void DrawMenu() {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin();
            spriteBatch.Draw(menyBak, new Vector2(0, 0), Color.White);
            switch (menuScene) {
                //Standard menu
                case 0:
                    spriteBatch.Draw(playKnapp, core.ui.graphics.playButton, Color.White);
                    spriteBatch.Draw(settings, core.ui.graphics.settingRec, Color.White);
                    spriteBatch.Draw(exit, core.ui.graphics.exitRec, Color.White);
                    core.ui.MenuButtons();
                    break;
                //Settings menu
                case 1:
                    if (debuggingMode == true) {
                        spriteBatch.Draw(disableDebug, core.ui.graphics.disableRec, Color.White);
                    } else {
                        spriteBatch.Draw(debug, core.ui.graphics.debugRec, Color.White);
                    }
                    spriteBatch.Draw(back, core.ui.graphics.backRec, Color.White);
                    if (debuggingMode == true && menuScene == 1) {
                        core.ui.DisableButton();
                    } else {
                        core.ui.SettingsButtons();
                    }
                    break;
            }
            spriteBatch.End();
        }
        void DrawGame() {
            GraphicsDevice.Clear(Color.DarkGray);
            
            spriteBatch.Begin();
            spriteBatch.Draw(bakgrundsbild, new Rectangle(0, 0, 696, 696), Color.White);
            for (int i = 0; i < activePiece.Count; i++) {
                if (isHolding == activePiece[i] && !activePiece[i].isDead) {
                    move(activePiece[i]);
                }
            }
            //Draw


            for (int i = 0; i < activePiece.Count; i++) {
                activePiece[i].Draw(spriteBatch);
            }


            Game1.debugger.Add("Runda: " + runda.ToString());
            debugger.Add("Blackcheck = " + blackCheck.ToString());
            debugger.Add("Whitecheck = " + whiteCheck.ToString());
            int tmp = 0;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (debuggingMode) {
                        spriteBatch.DrawString(arial, isTakenString[tmp], new Vector2(j * 87, i * 87), Color.White);
                    }
                    
                    tmp++;
                }
            }
            if (blackCheck == true && debuggingMode) {
                checkText = "Black king checked";
            } else if (whiteCheck == true && debuggingMode) {
                checkText = "White king checked";
            } else if (!blackCheck && !whiteCheck && debuggingMode) {
                checkText = "No king checked";
            }
            if (debuggingMode) {
                spriteBatch.DrawString(arial, checkText, new Vector2(750, 500), Color.Black);
            }
            if (debuggingMode == true) {
                spriteBatch.DrawString(arial, text, new Vector2(200, 200), Color.White);
                spriteBatch.DrawString(arial, text2, new Vector2(200, 300), Color.White);
                for (int i = 0; i < debugger.Count; i++) {
                    spriteBatch.DrawString(arial, debugger[i], new Vector2(750, 200 + i * 15), Color.Black);
                }
            }
            spriteBatch.Draw(back, core.ui.graphics.backRec2, Color.White);
            if (shackMatt && vitVinst) {
                spriteBatch.Draw(chessGray, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(whitewins, new Vector2(516 / 2, 348 - 348 / 4), Color.White);
                spriteBatch.Draw(newGame, core.ui.graphics.newGameRec, Color.White);
                spriteBatch.Draw(exit, core.ui.graphics.exitRec2, Color.White);
                debugger.Add("Game1 => Line 455 \n");
            } else if (shackMatt && !vitVinst) {
                spriteBatch.Draw(chessGray, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(blackwins, new Vector2(516 / 2, 348 - 348 / 4), Color.White);
                spriteBatch.Draw(exit, core.ui.graphics.exitRec2, Color.White);
                spriteBatch.Draw(newGame, core.ui.graphics.newGameRec, Color.White);
                debugger.Add("Game1 => Line 457 \n");
            }
            spriteBatch.End();
        }
        public void MouseUpdate() {
            gammalMus = mus;
            mus = Mouse.GetState();
            for (int i = 0; i < activePiece.Count; i++) {
                if (activePiece[i].rectangle.Contains(mus.Position) && (isHolding == activePiece[i] || mouseIsHolding == false)) {
                    isHolding = activePiece[i];
                    for (int j = 0; j < 64; j++) {
                        if (isHolding.am != null) {
                            isTakenString[j] = isHolding.am[j].ToString(); 
                        }
                    }
                    text2 = core.getBoard((int)activePiece[i].tempPos.X, (int)activePiece[i].tempPos.Y).ToString();
                    core.PieceUpdate(activePiece[i], core.getPos(activePiece[i]));
                }
            }
            core.ui.ForMouseUpdate();
        }
        
        /// <summary>
        /// Returns true if move leads to the king not being in check any longer
        /// </summary>
        /// <param name="a">The piece that has its move simulated</param>
        /// <returns></returns>
        public static bool SimulatedMove(Piece a, Piece b, int i) {
            Core thisCore = new Core();
            if (a is King) {
                return true;
            }
            a.ActualChecker(thisCore.getPos(a), false);
            if (a.am[i] && b.checkArray[i] && !(isWho[i] is King)) {
                debugger.Add("asdasdasd");
                return true;
            } else if (checkPieces.Contains(a) && i == thisCore.getBoard((int)theChecker.tempPos.X, (int)theChecker.tempPos.Y)) {
                return true;
            }
            return false;
        }
        void move(Piece a) {
            
            if (runda % 2 == 0 && a.isWhite == true && !whiteCheck) {
                a.am = new bool[64];
                a.ActualChecker(core.getPos(a), false);
                List<int> AllMoves = core.SimulateRound(a);
                for (int i = 0; i < 8 * 8; i++) {
                    if (a.rectangle.Contains(mus.Position) && core.ui.LeftMousePressed()) {
                        if (a.Checker(boardList[i]) && AllMoves.Contains(i)) {
                            a.allowedMoves[i] = true;
                            spriteBatch.Draw(red, boardList[i], Color.Green * 0.5f);
                        }
                        if (a.schack[i] == true && debuggingMode) {
                            spriteBatch.Draw(red, boardList[i], Color.Yellow);
                        }
                    }
                }
            } else if (runda % 2 == 0 && a.isWhite == true && whiteCheck) {
                for (int i = 0; i < 8 * 8; i++) {
                    if (a.rectangle.Contains(mus.Position) && core.ui.LeftMousePressed()) {
                        if (SimulatedMove(a, theChecker, i) || a is King) {
                            if (a.Checker(boardList[i])) {
                                a.allowedMoves[i] = true;
                                spriteBatch.Draw(red, boardList[i], Color.Green * 0.5f);
                            }
                            if (a.schack[i] == true && debuggingMode) {
                                spriteBatch.Draw(red, boardList[i], Color.Yellow);
                            }
                        }
                    }
                }
            }
            if (runda % 2 != 0 && a.isWhite == false && !blackCheck) {
                a.am = new bool[64];
                a.ActualChecker(core.getBoard((int)a.tempPos.X, (int)a.tempPos.Y), false);
                List<int> allMoves = core.SimulateRound(a);
                for (int i = 0; i < 8 * 8; i++) {
                    if (a.rectangle.Contains(mus.Position) && core.ui.LeftMousePressed()) {
                        if (a.Checker(boardList[i]) && allMoves.Contains(i)) {
                            a.allowedMoves[i] = true;
                            if (isWho[i] != null && isWho[i].isWhite != a.isWhite) {
                                spriteBatch.Draw(red, boardList[i], Color.Green * 0.5f);
                            } else if (isWho[i] == null) {
                                spriteBatch.Draw(red, boardList[i], Color.Green * 0.5f);
                            }
                        }
                        if (a.schack[i] == true && debuggingMode) {
                            spriteBatch.Draw(red, boardList[i], Color.Yellow);
                        }
                    }
                }
            } else if (runda % 2 != 0 && a.isWhite == false && blackCheck) {
                for (int i = 0; i < 8 * 8; i++) {
                    if (a.rectangle.Contains(mus.Position) && core.ui.LeftMousePressed()) {
                        if (SimulatedMove(a, theChecker, i) || a is King) {
                            if (a.Checker(boardList[i])) {
                                a.allowedMoves[i] = true;
                                if (isWho[i] != null && isWho[i].isWhite != a.isWhite) {
                                    spriteBatch.Draw(red, boardList[i], Color.Green * 0.5f);
                                } else if (isWho[i] == null) {
                                    spriteBatch.Draw(red, boardList[i], Color.Green * 0.5f);
                                }
                            }
                            if (a.schack[i] == true && debuggingMode) {
                                spriteBatch.Draw(red, boardList[i], Color.Yellow);
                            }
                        }
                    }
                }
            }
        }
    }
}

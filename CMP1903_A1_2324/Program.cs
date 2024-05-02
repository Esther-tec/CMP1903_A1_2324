namespace Dice_ConsoleApp;

public partial class Game : Form
{
            Statistics statistics = new Statistics();
            int playCount = 0;
            int highScore = 0;

            Form mainForm = new Form();
            Label title2DiesText = new Label();
            Label title5DiesText = new Label();
            Label introText = new Label();
            Label scorePlayer1 = new Label();
            Label scorePlayer2 = new Label();
            Button btnRoll = new Button();
            Button btnRoll5 = new Button();
            Button btn2Dies = new Button();
            Button btn5Dies = new Button();
            Button btn5DiesMakeChoice = new Button();
            RadioButton playComputerBtn = new RadioButton();
            RadioButton playOpponentBtn = new RadioButton();

            // 1 for player1, 2 for player 2
            int currentPlayerId = 1; // First player
            int player1Score = 0;
            int player2Score = 0;

            // GAME TYPE: 2 for twoDIes, 5 for fiveDies
            int gameType = -1;
            bool isThreeDies = false;

            // GAME MODE: 100 for play with computer, 200 for play with friend
            int gameMode = 200;

    public Game()
    {
        InitializeComponent();
        InitializeControls();
    }
    private void InitializeControls()
        {
            mainForm.Width = 1400;
            mainForm.Height = 1400;

            scorePlayer1.Text = "Player 1 score: 0";
            scorePlayer2.Text = "Player 2 score: 0";
            title2DiesText.Text = "2 Dies";
            title5DiesText.Text = "5 Dies"; 
            introText.Text = "Play die game.\nChoose game and type";

            btnRoll.Text = "Roll Die: Player 1";
            btnRoll5.Text = "Roll Die: Player 1";
            btn2Dies.Text = "2 Dies";
            btn5Dies.Text = "5 dies";
            btn5DiesMakeChoice.Text = "Choose";
            playComputerBtn.Text = "Play with computer";
            playOpponentBtn.Text = "Play with opponent";
 
            btnRoll5.Width = 300;
            btnRoll.Width = 300;
            introText.Width = 300;
            introText.Height = 50;
            playComputerBtn.Width = 300;
            playOpponentBtn.Width = 300;

            title2DiesText.Location = new Point(150, 50);
            title5DiesText.Location = new Point(150, 50);
            introText.Location = new Point(150, 50);
            scorePlayer1.Location = new Point(200, 70);
            scorePlayer2.Location = new Point(200, 90);
            playComputerBtn.Location = new Point(130, 120);
            playOpponentBtn.Location = new Point(130, 150);
            btn2Dies.Location = new Point(120, 200);
            btn5Dies.Location = new Point(220, 200);
            btn5DiesMakeChoice.Location = new Point(200, 200);
            btnRoll.Location = new Point(200, 200);
            btnRoll5.Location = new Point(200, 200);
            
            btnRoll.Click +=rollDiesClick;
            btnRoll5.Click +=roll5DiesClick;
            btn2Dies.Click +=btnTwoDies;
            btn5Dies.Click +=btnFiveDies;
            btn5DiesMakeChoice.Click += Game_Load;
            playComputerBtn.CheckedChanged  += radioComputerClick;
            playOpponentBtn.CheckedChanged  += radioOpponentClick;


            setHeaderTextMessage("Player 1 turn");
            this.Controls.Add(introText);
            this.Controls.Add(title2DiesText);
            this.Controls.Add(btnRoll); 
            this.Controls.Add(btnRoll5); 
            this.Controls.Add(scorePlayer1);
            this.Controls.Add(scorePlayer2);

            this.Controls.Add(title5DiesText);
            this.Controls.Add(btn2Dies); 
            this.Controls.Add(btn5Dies);
            this.Controls.Add(btn5DiesMakeChoice);
            this.Controls.Add(playComputerBtn); 
            this.Controls.Add(playOpponentBtn);

            makeAllInvisible();
            showIntro();
        }

        private void makeAllInvisible(){
            title2DiesText.Visible = false;
            title5DiesText.Visible = false;
            introText.Visible = false;
            scorePlayer1.Visible = false;
            scorePlayer2.Visible = false; 
            btnRoll.Visible = false;
            btnRoll5.Visible = false;
            btn2Dies.Visible = false;
            btn5Dies.Visible = false;
            playComputerBtn.Visible = false;
            playOpponentBtn.Visible = false;
            btn5DiesMakeChoice.Visible = false;

            title2DiesText.Invalidate();
            title5DiesText.Invalidate();
            introText.Invalidate();
            scorePlayer1.Invalidate();
            scorePlayer2.Invalidate();
            btnRoll.Invalidate();
            btnRoll5.Invalidate();
            btn2Dies.Invalidate();
            btn5Dies.Invalidate();
            playComputerBtn.Invalidate();
            playOpponentBtn.Invalidate();
            btn5DiesMakeChoice.Invalidate();
        }

        private void showIntro(){
            makeAllInvisible();
            introText.Visible = true;
            btn2Dies.Visible = true;
            btn5Dies.Visible = true;
            playComputerBtn.Visible = true;
            playOpponentBtn.Visible = true;

            introText.Invalidate();
            btn2Dies.Invalidate();
            btn5Dies.Invalidate();
            playComputerBtn.Invalidate();
            playOpponentBtn.Invalidate();
        }

        private void initTwoDies() {
            if (playComputerBtn.Checked == false && playOpponentBtn.Checked == false) {
                MessageBox.Show($"Select game type. Computer or Opponent");
                return;
            }
            makeAllInvisible();
            title2DiesText.Visible = true;
            scorePlayer1.Visible = true;
            scorePlayer2.Visible = true;
            btnRoll.Visible = true;
            title2DiesText.Invalidate();
            scorePlayer1.Invalidate();
            scorePlayer2.Invalidate();
            btnRoll.Invalidate();
        }

        private void initFiveDies() {
            if (playComputerBtn.Checked == false && playOpponentBtn.Checked == false) {
                MessageBox.Show($"Select game type. Computer or Opponent");
                return;
            }
            makeAllInvisible();
            title5DiesText.Visible = true;
            scorePlayer1.Visible = true;
            scorePlayer2.Visible = true;
            btnRoll5.Visible = true;
            title5DiesText.Invalidate();
            scorePlayer1.Invalidate();
            scorePlayer2.Invalidate();
            btnRoll.Invalidate();
        }

        private void btnTwoDies(object? sender, EventArgs e) {
            gameType = 2;
            initTwoDies();
        }

        private void btnFiveDies(object? sender, EventArgs e) {
            gameType = 5;
            initFiveDies();
        }

        private void rollDiesClick(object? sender, EventArgs e) {
            int sum = 0;
            Die die = new Die();
            int randomNumber1 = die.Roll(); 
            int randomNumber2 = die.Roll();
            sum = randomNumber1 + randomNumber2;
            if(randomNumber1 == randomNumber2){
                playCount += 1;
                setPlayerScore(sum * 2);
            } else if(sum == 7) {
                title2DiesText.Text = "Game Over";
                btnRoll.Visible = false;
                statistics.saveGameData(playCount, highScore);
            } else {
                playCount += 1;
                setPlayerScore(sum);
            }
        }

        private void roll5DiesClick(object? sender, EventArgs e) {
            playMethod();
        }

        private void playMethod() {
            int sum = 0;
            Die die = new Die();
            int randomNumber1 = die.Roll(); 
            int randomNumber2 = die.Roll(); 
            int randomNumber3 = die.Roll(); 
            int randomNumber4 = die.Roll(); 
            int randomNumber5 = die.Roll();

            sum = randomNumber1 + randomNumber2;
            
            int[] diceRolls = { randomNumber1, randomNumber2, randomNumber3 };
            if(isThreeDies == false) {
                Array.Resize(ref diceRolls, diceRolls.Length + 2);
                diceRolls[3] = randomNumber4;
                diceRolls[4] = randomNumber4;
            }
            bool hasFive = HasNumberOfKind(diceRolls, 5);
            bool hasFour = HasNumberOfKind(diceRolls, 4);
            bool hasThree = HasNumberOfKind(diceRolls, 3);
            bool hasTwo = HasNumberOfKind(diceRolls, 2);
            if (hasFive)
            {
                playCount += 1;
                setPlayerScore(12);
            }
            else if (hasFour)
            {
                playCount += 1;
                setPlayerScore(6); 
            }
            else if (hasThree)
            {
                playCount += 1;
                setPlayerScore(3); 
            }
            else if (hasTwo)
            {
                if(currentPlayerId == 2 && gameMode == 100) { // IF COMPUTER (To auomate playing)
                    playMethod();
                } else {
                    fiveDIesDoubleOccurence();
                }
                
            } else {
                playCount += 1;
                setPlayingID();
            }
        }

    bool HasNumberOfKind(int[] diceRolls, int kinds)
    {
        // Count the occurrences of each face value
        Dictionary<int, int> countMap = new Dictionary<int, int>();
        foreach (int roll in diceRolls)
        {
            if (!countMap.ContainsKey(roll))
            {
                countMap[roll] = 1;
            }
            else
            {
                countMap[roll]++;
            }
        }

        // Check if any face value occurs 3 times
        foreach (int count in countMap.Values)
        {
            if (count >= kinds)
            {
                return true;
            }
        }

        return false;
    }

        private void fiveDIesDoubleOccurence(){
            btnRoll5.Visible = false;
            btn5DiesMakeChoice.Visible = true;
            btn5DiesMakeChoice.Invalidate();
            btnRoll5.Invalidate();
        }

        private void fiveDIesDoubleOccurenceBackToNormal(){
            btnRoll5.Visible = true;
            btn5DiesMakeChoice.Visible = false;
            btn5DiesMakeChoice.Invalidate();
            btnRoll5.Invalidate();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            // Show a message box with two buttons ("Yes" and "No")
            DialogResult result = MessageBox.Show("Throw All (Yes) or remaining dies (No)?", "Confirmation", MessageBoxButtons.YesNo);

            // Check which button was clicked
            if (result == DialogResult.Yes)
            {
                isThreeDies = false;
                fiveDIesDoubleOccurenceBackToNormal();
            }
            else if (result == DialogResult.No)
            {
                isThreeDies = true;
                fiveDIesDoubleOccurenceBackToNormal();
            }
        }

        private void setPlayingID() {
            if(currentPlayerId == 1) {
                currentPlayerId = 2;
                btnRoll.Text = "Roll Die: Player 2";
                btnRoll5.Text = "Roll Die: Player 2";
                btnRoll.Invalidate();
                btnRoll5.Invalidate();

            } else {
                currentPlayerId = 1;
                btnRoll.Text = "Roll Die: Player 1";
                btnRoll5.Text = "Roll Die: Player 1";
                btnRoll.Invalidate();
                btnRoll5.Invalidate();
            }
        }

        private void setHeaderTextMessage(String msg) {
            title2DiesText.Text = msg;
        }

        private void setPlayerScore(int score) {
            if(currentPlayerId == 1) {
                player1Score = player1Score + score;
                scorePlayer1.Text = "Player 1 score: " +  player1Score;
                setHeaderTextMessage("Player 2 true");
                setPlayingID();
                if(gameMode == 100) {
                    computerPlays(); 
                }
            } else {
                player2Score = player2Score + score;
                scorePlayer2.Text = "Player 2 score: " +  player2Score;
                setHeaderTextMessage("Player 1 turn");
                setPlayingID();
            }
            if(player1Score >= 20){
                btnRoll.Visible = false;
                btnRoll5.Visible = false; 
                btnRoll.Invalidate();
                btnRoll5.Invalidate();
                highScore = player1Score;
                statistics.saveGameData(playCount, highScore);
                MessageBox.Show("Game Over\nPlayer 1 won");
            } else if(player2Score >= 20){ 
                btnRoll.Visible = false;
                btnRoll5.Visible = false;
                btnRoll.Invalidate();
                btnRoll5.Invalidate();
                highScore = player2Score;
                statistics.saveGameData(playCount, highScore);
                MessageBox.Show("Game Over\nPlayer 2 won");
            }
        }

        private void computerPlays() { 
            MessageBox.Show("Computer played.");
            playMethod();
        }

        private void radioComputerClick(object sender, EventArgs e) { 
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked) {
                gameMode = 100;
                playOpponentBtn.Checked  = false;
                playOpponentBtn.Invalidate();
            }
        }

        private void radioOpponentClick(object sender, EventArgs e) { 
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked) {
                gameMode = 200;
                playComputerBtn.Checked  = false;
                playComputerBtn.Invalidate();
            }
        }
}

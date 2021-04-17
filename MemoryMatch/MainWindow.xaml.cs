using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace MemoryMatch {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {      

        private int card1 = 0, card2 = 0, card3 = 0, card4 = 0, card5 = 0, card6 = 0, card7 = 0, card8 = 0, card9 = 0, card10 = 0, card11 = 0, card12 = 0;
        private int randomNum = 0;
        private int numMatches = 0;
        private int counter = 0;
        private int mistakes = 0;
        private int numSelectedCards = 0;
        private int totalNumMatchesRemoved = 0;
        private int firstSelectedCard = 0;

        private Image firstSelectedImage = new Image();
        private Border firstSelectedBorder = new Border();

        public MainWindow() {
            InitializeComponent();
            var uriSource = new Uri("./images/CardPair_sm.png", UriKind.Relative);
            pbMatch1.Source = new BitmapImage(uriSource);
            pbMatch2.Source = new BitmapImage(uriSource);
            pbMatch3.Source = new BitmapImage(uriSource);
            pbMatch4.Source = new BitmapImage(uriSource);
            pbMatch5.Source = new BitmapImage(uriSource);
            pbMatch6.Source = new BitmapImage(uriSource);

            PlayGame();
        }

        private void BtnPlayAgain_Click(object sender, EventArgs e) {
            PlayGame();
        } // end btnPlayAgain_Click

        private void PlayGame() {
            card1 = 0;
            card2 = 0;
            card3 = 0;
            card4 = 0;
            card5 = 0;
            card6 = 0;
            card7 = 0;
            card8 = 0;
            card9 = 0;
            card10 = 0;
            card11 = 0;
            card12 = 0;

            randomNum = 0;
            numMatches = 0;
            counter = 0;
            mistakes = 0;
            numSelectedCards = 0;
            totalNumMatchesRemoved = 0;
            firstSelectedCard = 0;
            firstSelectedBorder = new Border();
            firstSelectedImage = new Image();

            lblCongrats.Visibility = Visibility.Hidden;
            btnPlayAgain.Visibility = Visibility.Hidden;

            pbBorder1.Visibility = Visibility.Visible;
            pbBorder2.Visibility = Visibility.Visible;
            pbBorder3.Visibility = Visibility.Visible;
            pbBorder4.Visibility = Visibility.Visible;
            pbBorder5.Visibility = Visibility.Visible;
            pbBorder6.Visibility = Visibility.Visible;
            pbBorder7.Visibility = Visibility.Visible;
            pbBorder8.Visibility = Visibility.Visible;
            pbBorder9.Visibility = Visibility.Visible;
            pbBorder10.Visibility = Visibility.Visible;
            pbBorder11.Visibility = Visibility.Visible;
            pbBorder12.Visibility = Visibility.Visible;

            pbMatch1.Visibility = Visibility.Hidden;
            pbMatch2.Visibility = Visibility.Hidden;
            pbMatch3.Visibility = Visibility.Hidden;
            pbMatch4.Visibility = Visibility.Hidden;
            pbMatch5.Visibility = Visibility.Hidden;
            pbMatch6.Visibility = Visibility.Hidden;

            var uriSource = new Uri("./images/cardBack.jpg", UriKind.Relative);

            pictureBox1.Source = new BitmapImage(uriSource);
            pictureBox2.Source = new BitmapImage(uriSource);
            pictureBox3.Source = new BitmapImage(uriSource);
            pictureBox4.Source = new BitmapImage(uriSource);
            pictureBox5.Source = new BitmapImage(uriSource);
            pictureBox6.Source = new BitmapImage(uriSource);
            pictureBox7.Source = new BitmapImage(uriSource);
            pictureBox8.Source = new BitmapImage(uriSource);
            pictureBox9.Source = new BitmapImage(uriSource);
            pictureBox10.Source = new BitmapImage(uriSource);
            pictureBox11.Source = new BitmapImage(uriSource);
            pictureBox12.Source = new BitmapImage(uriSource);

            lblMistakes.Content = "";

            Random r = new Random();

            while (numMatches < 6) {
                randomNum = r.Next(1, 13);
                switch(randomNum) {
                    case 1:
                        if (card1 == 0) {
                            card1 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 2:
                        if (card2 == 0) {
                            card2 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 3:
                        if (card3 == 0) {
                            card3 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 4:
                        if (card4 == 0) {
                            card4 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 5:
                        if (card5 == 0) {
                            card5 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 6:
                        if (card6 == 0) {
                            card6 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 7:
                        if (card7 == 0) {
                            card7 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 8:
                        if (card8 == 0) {
                            card8 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 9:
                        if (card9 == 0) {
                            card9 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 10:
                        if (card10 == 0) {
                            card10 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 11:
                        if (card11 == 0) {
                            card11 = numMatches + 1;
                            counter++;
                        }
                        break;
                    case 12:
                        if (card12 == 0) {
                            card12 = numMatches + 1;
                            counter++;
                        }
                        break;
                } // end switch

                if (counter == 2) {
                    numMatches++;
                    counter = 0;
                }
            } // end while
        } // end PlayGame

        private void DisplayMatches() {
            for (int x = 1; x <= totalNumMatchesRemoved; x++) {
                switch(x) {
                    case 1:
                        pbMatch1.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        pbMatch2.Visibility = Visibility.Visible;
                        break;
                    case 3:
                        pbMatch3.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        pbMatch4.Visibility = Visibility.Visible;
                        break;
                    case 5:
                        pbMatch5.Visibility = Visibility.Visible;
                        break;
                    case 6:
                        pbMatch6.Visibility = Visibility.Visible;
                        break;
                } // end switch
            } // end for
        } // end DisplayMatches

        private void PictureBox_Click(object sender, EventArgs e) {
            Image currentImage = new Image();
            Border currentBorder = new Border();

            currentImage = (Image)sender;

            numSelectedCards++;

            var uriSource = new Uri("./images/kitten.jpg", UriKind.Relative);

            int currentCard = 0;

            if(currentImage.Name == "pictureBox1") {
                currentCard = card1;
                currentBorder = pbBorder1;
            } else if (currentImage.Name == "pictureBox2") {
                currentCard = card2;
                currentBorder = pbBorder2;
            } else if (currentImage.Name == "pictureBox3") {
                currentCard = card3;
                currentBorder = pbBorder3;
            } else if (currentImage.Name == "pictureBox4") {
                currentCard = card4;
                currentBorder = pbBorder4;
            } else if (currentImage.Name == "pictureBox5") {
                currentCard = card5;
                currentBorder = pbBorder5;
            } else if (currentImage.Name == "pictureBox6") {
                currentCard = card6;
                currentBorder = pbBorder6;
            } else if (currentImage.Name == "pictureBox7") {
                currentCard = card7;
                currentBorder = pbBorder7;
            } else if (currentImage.Name == "pictureBox8") {
                currentCard = card8;
                currentBorder = pbBorder8;
            } else if (currentImage.Name == "pictureBox9") {
                currentCard = card9;
                currentBorder = pbBorder9;
            } else if (currentImage.Name == "pictureBox10") {
                currentCard = card10;
                currentBorder = pbBorder10;
            } else if (currentImage.Name == "pictureBox11") {
                currentCard = card11;
                currentBorder = pbBorder11;
            } else if (currentImage.Name == "pictureBox12") {
                currentCard = card12;
                currentBorder = pbBorder12;
            }

            if (currentCard == 1) {
                uriSource = new Uri("./images/kitten.jpg", UriKind.Relative);
            } else if (currentCard == 2) {
                uriSource = new Uri("./images/puppy.jpg", UriKind.Relative);
            } else if (currentCard == 3) {
                uriSource = new Uri("./images/funnyMonkey.jpg", UriKind.Relative);
            } else if (currentCard == 4) {
                uriSource = new Uri("./images/polarBears.jpg", UriKind.Relative);
            } else if (currentCard == 5) {
                uriSource = new Uri("./images/WileECoyote.jpg", UriKind.Relative);
            } else if (currentCard == 6) {
                uriSource = new Uri("./images/roadrunner.gif", UriKind.Relative);
            }

            currentImage.Source = new BitmapImage(uriSource);

            if (numSelectedCards == 2) {

                // TODO: If the player clicks too fast on the image, the game will register as if the player got a match
                Thread.Sleep(100);
                WpfApplication.DoEvents();
                Thread.Sleep(100);
                WpfApplication.DoEvents();
                Thread.Sleep(1200);
                WpfApplication.DoEvents();

                if (firstSelectedCard == currentCard) {
                    currentBorder.Visibility = Visibility.Hidden;
                    firstSelectedBorder.Visibility = Visibility.Hidden;

                    totalNumMatchesRemoved++;

                    DisplayMatches();

                    if (totalNumMatchesRemoved == 6) {
                        lblCongrats.Visibility = Visibility.Visible;
                        btnPlayAgain.Visibility = Visibility.Visible;
                    } // end show congrats
                } else {
                    mistakes++;
                    lblMistakes.Content = mistakes.ToString();

                    uriSource = new Uri("./images/cardBack.jpg", UriKind.Relative);

                    pictureBox1.Source = new BitmapImage(uriSource);
                    pictureBox2.Source = new BitmapImage(uriSource);
                    pictureBox3.Source = new BitmapImage(uriSource);
                    pictureBox4.Source = new BitmapImage(uriSource);
                    pictureBox5.Source = new BitmapImage(uriSource);
                    pictureBox6.Source = new BitmapImage(uriSource);
                    pictureBox7.Source = new BitmapImage(uriSource);
                    pictureBox8.Source = new BitmapImage(uriSource);
                    pictureBox9.Source = new BitmapImage(uriSource);
                    pictureBox10.Source = new BitmapImage(uriSource);
                    pictureBox11.Source = new BitmapImage(uriSource);
                    pictureBox12.Source = new BitmapImage(uriSource);
                }

                numSelectedCards = 0;
                firstSelectedCard = 0;
                firstSelectedBorder = new Border();
                firstSelectedImage = new Image();
            } else if (firstSelectedCard == 0) {
                firstSelectedCard = currentCard;
                firstSelectedImage = currentImage;
                firstSelectedBorder = currentBorder;
            }
        } // end PictureBox_Click

    } // end class
} // end namespace

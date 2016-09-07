﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using League_Autoplay.High_Performance_Timer;
using Debug = System.Diagnostics.Debug;

namespace League_Autoplay.AutoQueue
{
    public class AutoQueueManager
    {
        bool test = false;

        Bitmap acceptMatchButton, dontSendButton, randomChampButton, reconnectButton, playAgainButton;
        Position acceptMatchButtonPosition, dontSendButtonPosition, randomChampButtonPosition, reconnectButtonPosition, playAgainButtonPosition;
        Stopwatch acceptMatchClickStopwatch, dontSendClickStopwatch, randomChampClickStopwatch, reconnectButtonClickStopwatch, playAgainButtonStopwatch;

        public AutoQueueManager()
        {
            string dir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            acceptMatchButton = new Bitmap(Image.FromFile(Path.Combine(dir, "AnalysisImages\\Resources\\Auto Queue Images\\Accept Match Button.png")));
            dontSendButton = new Bitmap(Image.FromFile(Path.Combine(dir, "AnalysisImages\\Resources\\Auto Queue Images\\Dont Send Button.png")));
            randomChampButton = new Bitmap(Image.FromFile(Path.Combine(dir, "AnalysisImages\\Resources\\Auto Queue Images\\Random Champ Button.png")));
            reconnectButton = new Bitmap(Image.FromFile(Path.Combine(dir, "AnalysisImages\\Resources\\Auto Queue Images\\Reconnect Button.png")));
            playAgainButton = new Bitmap(Image.FromFile(Path.Combine(dir, "AnalysisImages\\Resources\\Auto Queue Images\\Play Again Button.png")));

            acceptMatchClickStopwatch = new Stopwatch();
            dontSendClickStopwatch = new Stopwatch();
            randomChampClickStopwatch = new Stopwatch();
            reconnectButtonClickStopwatch = new Stopwatch();
            playAgainButtonStopwatch = new Stopwatch();
        }

        public void reset()
        {

        }
        public void runAutoQueue(Bitmap screen)
        {

            //Loop through pixels on the screen and look for any of those four buttons.
            if (acceptMatchClickStopwatch.DurationInMilliseconds() >= 500 || test)
            {
                //Console.WriteLine("Scanning for accept match button");
                acceptMatchButtonPosition = AutoQueueDetection.findImageInScreen(screen, acceptMatchButton, 366, 393, 10, 10, 0.95);
                //acceptMatchButtonPosition = AutoQueueDetection.findImageInScreen(screen, acceptMatchButton, 0, 0, 1024, 768, 0.5);
                if (acceptMatchButtonPosition.x != -1)
                {
                    Console.WriteLine("\tFound accept match button at " + acceptMatchButtonPosition.x + ", " + acceptMatchButtonPosition.y);
                    if (!test)
                    {
                        MotorCortex.clickMouseAt(acceptMatchButtonPosition.x + 10, acceptMatchButtonPosition.y + 10);
                        moveMouseToWithDelay(0, 0, 200);
                    }
                }
                acceptMatchClickStopwatch.Reset();
                return;
            }


            if (dontSendClickStopwatch.DurationInMilliseconds() >= 500 || test)
            {
                dontSendButtonPosition = AutoQueueDetection.findImageInScreen(screen, dontSendButton, 465, 535, 10, 10, 0.95);
                if (dontSendButtonPosition.x != -1)
                {
                    Console.WriteLine("\tFound dont send button");
                    if (!test)
                    {
                        MotorCortex.clickMouseAt(dontSendButtonPosition.x + 10, dontSendButtonPosition.y + 10);
                        moveMouseToWithDelay(0, 0, 200);
                    }
                    dontSendClickStopwatch.Reset();
                    return;
                }
            }

            if (randomChampClickStopwatch.DurationInMilliseconds() >= 2000 || test)
            {
                randomChampButtonPosition = AutoQueueDetection.findImageInScreen(screen, randomChampButton, 235, 186, 10, 10, 0.95);
                if (randomChampButtonPosition.x != -1)
                {
                    Console.WriteLine("\tFound random champ button");
                    if (!test)
                    {
                        MotorCortex.clickMouseAt(randomChampButtonPosition.x + 10, randomChampButtonPosition.y + 10);
                        moveMouseToWithDelay(0, 0, 200);

                        //Click Enter
                        Task.Delay(200).ContinueWith(_ =>
                        {
                            MotorCortex.typeText("{ENTER}");
                        });
                        Task.Delay(400).ContinueWith(_ =>
                        {
                            MotorCortex.typeText("T", true);
                        });
                        Task.Delay(600).ContinueWith(_ =>
                        {
                            MotorCortex.typeText("o", true);
                        });
                        Task.Delay(800).ContinueWith(_ =>
                        {
                            MotorCortex.typeText("p", true);
                        });
                        Task.Delay(1000).ContinueWith(_ =>
                        {
                            MotorCortex.typeText("{ENTER}");
                        });
                    }
                    randomChampClickStopwatch.Reset();
                    return;
                }
            }

            if (reconnectButtonClickStopwatch.DurationInMilliseconds() >= 500 || test)
            {
                reconnectButtonPosition = AutoQueueDetection.findImageInScreen(screen, reconnectButton, 438, 394, 10, 10, 0.95);
                if (reconnectButtonPosition.x != -1)
                {
                    Console.WriteLine("\tFound reconnect button");
                    if (!test)
                    {
                        MotorCortex.clickMouseAt(reconnectButtonPosition.x + 10, reconnectButtonPosition.y + 10);
                        moveMouseToWithDelay(0, 0, 200);
                    }
                    reconnectButtonClickStopwatch.Reset();
                    return;
                }
            }

            if (playAgainButtonStopwatch.DurationInMilliseconds() >= 500 || test)
            {
                playAgainButtonPosition = AutoQueueDetection.findImageInScreen(screen, playAgainButton, 776, 616, 10, 10, 0.95);
                if (playAgainButtonPosition.x != -1)
                {
                    Console.WriteLine("\tFound play again button");
                    if (!test)
                    {
                        MotorCortex.clickMouseAt(playAgainButtonPosition.x + 10, playAgainButtonPosition.y + 10);
                        moveMouseToWithDelay(0, 0, 200);
                    }
                    playAgainButtonStopwatch.Reset();
                    return;
                }
            }
        }
        public void enteredLeagueOfLegends()
        {

        }
        public void exitedLeagueOfLegends()
        {
            MotorCortex.moveMouseTo(0, 0, 1);
        }
        public void clickMouseAtWithDelay(int x, int y, int delay)
        {
            Task.Delay(delay).ContinueWith(_ =>
            {
                MotorCortex.clickMouseAt(x, y, 1);
            });
        }
        public void moveMouseToWithDelay(int x, int y, int delay)
        {
            Task.Delay(delay).ContinueWith(_ =>
            {
                MotorCortex.moveMouseTo(x, y, 1);
            });
        }
    }
}

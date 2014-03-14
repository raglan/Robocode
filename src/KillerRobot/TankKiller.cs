using Robocode;
using System.Drawing;
using Robocode.Util;

namespace TJY
{
    public class TankKiller : Robot
    {
        public int Count;
        public double GunTurnAmount;
        public string TrackName;
        public override void Run()
        {
            BodyColor = (Color.FromArgb(128, 128, 50));
            GunColor = (Color.FromArgb(50, 50, 20));
            RadarColor = (Color.FromArgb(200, 200, 70));
            ScanColor = (Color.White);
            BulletColor = (Color.Blue);

            IsAdjustGunForRobotTurn = false;
            Count = 0;
            GunTurnAmount = 10;

             while (true)
            {
                TurnGunRight(GunTurnAmount);
                Count++;
                if (Count > 2)
                {
                    GunTurnAmount = -10;
                }
                if (Count > 5)
                {
                    GunTurnAmount = 10;
                }
                if (Count > 11)
                {
                    TrackName = null;
                }
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            if (TrackName != null && evnt.Name != TrackName)
            {
                return;
            }

            // If we don't have a target, well, now we do!
            if (TrackName == null)
            {
                TrackName = evnt.Name;
                Out.WriteLine("Tracking " + TrackName);
            }
            // This is our target.  Reset count (see the run method)
            Count = 0;
            // If our target is too far away, turn and move toward it.
            if (evnt.Distance > 150)
            {
                GunTurnAmount = Utils.NormalRelativeAngleDegrees(evnt.Bearing + (Heading - RadarHeading));

                TurnGunRight(GunTurnAmount); // Try changing these to setTurnGunRight,
                TurnRight(evnt.Bearing); // and see how much Tracker improves...
                // (you'll have to make Tracker an AdvancedRobot)
                Ahead(evnt.Distance - 140);
                return;
            }

            // Our target is close.
            GunTurnAmount = Utils.NormalRelativeAngleDegrees(evnt.Bearing + (Heading - RadarHeading));
            TurnGunRight(GunTurnAmount);
            Fire(3);

            // Our target is too close!  Back up.
            if (evnt.Distance < 100)
            {
                if (evnt.Bearing > -90 && evnt.Bearing <= 90)
                {
                    Back(40);
                }
                else
                {
                    Ahead(40);
                }
            }
            Scan();
        }

        /// <summary>
        ///   onHitRobot:  Set him as our new target
        /// </summary>
        public override void OnHitRobot(HitRobotEvent e)
        {
            // Only print if he's not already our target.
            if (TrackName != null && TrackName != e.Name)
            {
                Out.WriteLine("Tracking " + e.Name + " due to collision");
            }
            // Set the target
            TrackName = e.Name;
            // Back up a bit.
            // Note:  We won't get scan events while we're doing this!
            // An AdvancedRobot might use setBack(); Execute();
            GunTurnAmount = Utils.NormalRelativeAngleDegrees(e.Bearing + (Heading - RadarHeading));
            TurnGunRight(GunTurnAmount);
            Fire(3);
            Back(50);
        }

        /// <summary>
        ///   onWin:  Do a victory dance
        /// </summary>
        public override void OnWin(WinEvent e)
        {
            for (int i = 0; i < 50; i++)
            {
                TurnRight(30);
                TurnLeft(30);
            }
        }
    }
}

using Robocode;
using Robocode.Util;
using System;
using System.Drawing;

namespace TJY
{
    public class TankKiller : AdvancedRobot
    {
        #region Member Variables

        private double _direction;
        private double _deathCount;
        private Random _randomGenerator;

        #endregion Member Variables

        #region AdvancedRobot Members

        public override void Run()
        {
            BulletColor = (Color.Red);
            this._randomGenerator = new Random();
            this._direction = double.PositiveInfinity;
            SetTurnRadarRightRadians(this._direction);
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            var index = 30;
            int matchPosition;

            SetAhead(this._direction *= (0.92 - (this._deathCount > 1.25 ? this._randomGenerator.Next() : (Math.Round(_deathCount) - (this.getTime() % 13)))));

            var absoluteBearing = evnt.BearingRadians + HeadingRadians;
            enemyHistory = string.Concat((char)(evnt.Velocity * (Math.Sin(evnt.HeadingRadians - (absoluteBearing)))), enemyHistory);

            while (true)
            {
                matchPosition = enemyHistory.IndexOf(enemyHistory.Substring(0, index--), 64);
                if (matchPosition >= 0)
                {
                    break;
                }
            }

            index = (int)evnt.Distance;
            SetTurnRightRadians(Math.Cos(evnt.BearingRadians) - ((index - 250) * Velocity / 3200));

            do
            {
                absoluteBearing += (((short)enemyHistory[--matchPosition]) / evnt.Distance);
            } while ((index -= 13) > 0);

            SetTurnGunRightRadians(Utils.NormalRelativeAngle(absoluteBearing - GunHeadingRadians));
            //don't ask... Math is complicated
            SetFire(2.333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333);

            SetTurnRadarLeftRadians(RadarTurnRemainingRadians);
        }

        public override void OnDeath(DeathEvent evnt)
        {
            this._deathCount += 0.25;
        }

        public override void OnHitWall(HitWallEvent evnt)
        {
            this._direction *= -1.0;
        }

        #endregion AdvancedRobot Members

        #region Private Members

        private double getTime()
        {
            return (double)DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private static String enemyHistory =
            unchecked(
                ""
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)1
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)2
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)-1
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)0 + (char)0 + (char)0
                + (char)0 + (char)-2 + (char)-4 + (char)-6
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-8 + (char)-8 + (char)-8 + (char)-8
                + (char)-7 + (char)-6 + (char)-5 + (char)-4
                + (char)-3 + (char)-2 + (char)-1 + (char)0
                + (char)2 + (char)4 + (char)6 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)8 + (char)8 + (char)8 + (char)8
                + (char)7 + (char)6 + (char)5 + (char)4
                + (char)3 + (char)2 + (char)1 + (char)0);

        #endregion Private Members
    }
}

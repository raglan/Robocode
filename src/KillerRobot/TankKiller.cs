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
        private string _target;
        private int _searchTimeout;

        #endregion Member Variables

        #region AdvancedRobot Members

        public override void Run()
        {
            BulletColor = (Color.Red);
            _target = "";
            _searchTimeout = 0;
            this._randomGenerator = new Random();
            this._direction = double.PositiveInfinity;
            SetTurnRadarRightRadians(this._direction);
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            //if this is not our target return immediately
            if (!string.Equals("", _target) && !string.Equals(evnt.Name, _target))
            {
                if (_searchTimeout > 10)
                {
                    _target = "";
                    _searchTimeout = 0;
                }
                else
                {
                    _searchTimeout++;
                    return;                    
                }
            }

            //we have a target;
            _target = evnt.Name;
            _searchTimeout = 0;
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void OnDeath(DeathEvent evnt)
        {
            this._deathCount += 0.25;
        }

        public override void OnHitWall(HitWallEvent evnt)
        {
            this._direction = (this._direction + 45) * -1;
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            if (!string.Equals(_target, evnt.Name))
            {
                _target = evnt.Name;
            }
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

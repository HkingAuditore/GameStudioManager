using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStdioManager.Models.Staff
{
    public enum TalkChoice
    {
        Reward,
        Penalize,
        Promote,
        Demote,
        Fire
    }

    public partial class Staff
    {
        public string Greet()
        {
            if (this.StaffLoyalty < 50)
            {
                return "有何吩咐？";
            }
            else if (this.StaffLoyalty < 70)
            {
                return "您找我有事吗？";
            }
            else
            {
                return "老板，您好！";
            }
        }

        public string Talk(TalkChoice tc)
        {
            switch (tc)
            {
                case TalkChoice.Reward:
                    return this.Reward();
                    break;
                case TalkChoice.Penalize:
                    return this.Penalize();
                    break;
                case TalkChoice.Promote:
                    return this.Promote();
                    break;
                case TalkChoice.Demote:
                    return this.Demote();
                    break;
                case TalkChoice.Fire:
                    return this.Fire();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tc), tc, null);
            }
        }

        private string Fire()
        {
            this.IsWorking = false;
            Studio.Studio tmpStudio = this.StaffStudioObject;
            tmpStudio.StudioDevelopingGames.ForEach(project =>
                                                    {
                                                        if (project.Developers.Contains(this))
                                                            project.RemoveDeveloper(this);
                                                    });
            this.StaffStudio       = "无业";
            this.WeekdaysLength = 0;
            this.TimeToWork = -1;
            this.TimeToQuit = -1;
            this.StaffStudioObject = null;
            this.UpdateSql();
            this.StaffLoyalty = (int)(0.6 * this.StaffLoyalty);
            if (this.StaffLoyalty < 50)
            {
                return "我早就不想干了！";
            }
            else if (this.StaffLoyalty < 70)
            {
                return "为什么？？？？";
            }
            else
            {
                return "是我...哪里做错了吗？";
            }

        }

        private string Demote()
        {
            this.StaffRank -= 1;
            this.StaffLoyalty = (int)(0.8 * this.StaffLoyalty);
            this.UpdateSql();
            if (this.StaffLoyalty < 50)
            {
                return "我怎么做才能让你满意。";
            }
            else if (this.StaffLoyalty < 70)
            {
                return "好吧。";
            }
            else
            {
                return "对不起，让您失望了。";
            }

        }

        private string Promote()
        {
            this.StaffRank += 1;
            this.StaffLoyalty = (int)(1.1 * this.StaffLoyalty);
            this.UpdateSql();
            if (this.StaffLoyalty < 50)
            {
                return "谢谢。";
            }
            else if (this.StaffLoyalty < 70)
            {
                return "感谢！";
            }
            else
            {
                return "我会加把劲的！";
            }
        }

        private string Penalize()
        {
            this.StaffSalary = (int) (this.StaffSalary * 0.8);
            this.StaffLoyalty = (int)(0.8 * this.StaffLoyalty);
            this.UpdateSql();
            if (this.StaffLoyalty < 50)
            {
                return "又...？好吧。";
            }
            else if (this.StaffLoyalty < 70)
            {
                return "啊...";
            }
            else
            {
                return "对不起，让您失望了。";
            }
        }

        private string Reward()
        {
            this.StaffSalary = (int)(this.StaffSalary * 1.2);
            this.StaffLoyalty = (int)(1.1 * this.StaffLoyalty);
            this.UpdateSql();
            if (this.StaffLoyalty < 50)
            {
                return "谢谢。";
            }
            else if (this.StaffLoyalty < 70)
            {
                return "感谢！";
            }
            else
            {
                return "我会加把劲的！";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Argus.src
{
    public enum MODE
    {
        SECONDS,
        MINUTES,
        HOURS
    }

    public class ArgusIngredient
    {
        public SystemUsageDAO usageDAO { get; set; }
        public int interval { get; set; }
        public string chartXaxisText { get; set; }

        public ArgusIngredient(MODE mode)
        {
            switch (mode)
            { 
                case MODE.SECONDS:
                    usageDAO = new SystemUsageDAO("ArgusDBSeconds.db");
                    interval = 5 * 1000;
                    chartXaxisText = "seconds ago";
                    break;
                case MODE.MINUTES:
                    usageDAO = new SystemUsageDAO("ArgusDBMInutes.db");
                    interval = 5 * 60 * 1000;
                    chartXaxisText = "minutes ago";
                    break;
                case MODE.HOURS:
                    usageDAO = new SystemUsageDAO("ArgusDBHours.db");
                    interval = 60 * 60 * 1000;
                    chartXaxisText = "hours ago";
                    break;
            }
        }

    }

    public class ModeToIngredientMapperFactory
    {
        public static Dictionary<MODE, ArgusIngredient> Create()
        {
            Dictionary<MODE, ArgusIngredient> mapper = new Dictionary<MODE, ArgusIngredient>();
            mapper.Add(MODE.SECONDS, new ArgusIngredient(MODE.SECONDS));
            mapper.Add(MODE.MINUTES, new ArgusIngredient(MODE.MINUTES));
            mapper.Add(MODE.HOURS, new ArgusIngredient(MODE.HOURS));

            return mapper;
        }
    }
}

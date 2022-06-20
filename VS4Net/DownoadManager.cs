using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS4Net
{
    class DownoadManager
    {
        private static DownoadManager instance;
        public static DownoadManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DownoadManager();
                return instance;
            }
        }
        public bool Running { get; private set; }
        private List<string> List { get; }
        private DownoadManager()
        {
            Running = false;
            List = new List<string>();
        }
        public void Add(string link)
        {
            List.Add(link);
        }
        public void Start()
        {
            if (List != null && List.Count > 0)
            {
                Running = true;



            }
        }
        public void About()
        {

            Running = false;
        }
    }
}
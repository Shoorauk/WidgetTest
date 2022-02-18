using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Script.Config
{
    public class ConfigSetting
    {
        public string BaseUrl { get; set; }
        public string SessionValue { get; set; }

        public string SessionKey { get; set; }
        
        public string yopmailURl { get; set; }
    }


    public class TemplateConfigurations
    {
        public List<Mapping> Mapping { get; set; }

    }

    public class Mapping
    {
        public string EndPointRequest { get; set; }
        public List<Map> Map { get; set; }
    }

    public class Map
    {
        public string GetUrl { get; set; }

        public Header Header { get; set; }
    }

    public class Header
    {
        public string SessionValue { get; set; }
        public string SessionKey { get; set; }
        public string Header3 { get; set; }

    }



}


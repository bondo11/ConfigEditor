﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class OrRule : Match
    {
        List<Match> matchRules = new List<Match>();

        public void add(Match matchRule)
        {
            matchRules.Add(matchRule);
        }
    }
}

﻿using ICities;

using System.IO;

namespace Chitter
{
    public class ChitterMod : IUserMod
    {
        public string Name
        {
            get 
            {
                return "Chitter ";
            }
        }

        public string Description
        {
            get 
            {
                return "Reads tweets from twitter and displays them as chirper messages.";
            }
        }
    }
}

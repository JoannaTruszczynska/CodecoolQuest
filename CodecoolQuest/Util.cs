using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Codecool.Quest
{
    public static class Util

    {
        public static int RandomNumber(int x, int y)
        {
            Random rand = new Random();
            return rand.Next(x, y);

        }
    }
}
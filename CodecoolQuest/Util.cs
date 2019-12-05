using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Codecool.Quest
{
    public static class Util

    {
        private static readonly Random rand = new Random();
        public static int RandomNumber(int x, int y)
        {

            return rand.Next(x, y);

        }
    }
}
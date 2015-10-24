using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using Emoticoner.Emoticons;
using Emoticoner.Helpers;

namespace Emoticoner.Algo
{
    class Placer
    {
        List<List<int>> now = new List<List<int>>();
        bool[] is_used;
        int[] length;
        int[] cur_place;
        int[] best_place;
        int best_used;
        int num;
        int to_use;
        int width;
        bool exit = false;

        void rec(int used, int len)
        {
            if (!exit)
            {
                for (int i = 0; i < num; i++)
                {
                    if (exit == false && is_used[i] == false && len % width + length[i] <= width)
                    {
                        is_used[i] = true;
                        cur_place[used] = i;
                        rec(used + 1, len + length[i]);
                        if (used + 1 > best_used)
                        {
                            best_place = (int[])cur_place.Clone();
                            best_used = used + 1;
                            if (best_used == to_use)
                            {
                                exit = true;
                            }
                        }
                        cur_place[used] = -1;
                        is_used[i] = false;
                    }
                }
            }
        }

        public List<Emoticon> Place(List<Emoticon> emoticons, Font font, int width, int cols)
        {
            var a = new List<Pair<Emoticon, int>>();
            for (int i = 0; i < emoticons.Count; i++)
            {
                a.Add(new Pair<Emoticon, int>(emoticons[i], emoticons[i].TileWidth(font, width)));
            }

            return Place(a, cols);
        }

        public List<Emoticon> Place(List<Pair<Emoticon, int>> a, int _width)
        {
            var verified = a.Where(item => item.second <= _width).ToList();
            num = verified.Count;
            width = _width;
            length = new int[num];
            is_used = new bool[num];
            cur_place = new int[num];
            best_place = new int[num];
            best_used = 0;
            to_use = num;

            for (int i = 0; i < num; i++)
            {
                is_used[i] = false;
                length[i] = verified[i].second;
            }
            rec(0, 0);
            var result = new List<Emoticon>();
            for (int i = 0; i < num; i++)
            {
                result.Add(verified[best_place[i]].first);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorEpicDuels
{
    public class BinaryTree<T> where T :   class  
    {
        //public BaseGladiator T Data { get; set; }
        public T Data { get; set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        private bool _isLeft = true;

        private List<T> _pairToCompetition { get; set; } = new List<T>();

        //public BinaryTree(BaseGladiator gladiator) => Data = gladiator;

        public void Insert(T data)
        {
            // 1. data == null and left and right null 
            // 2. data != null , and left and right null
            // 3. data !=null , left and right have value

            if (Data == null && Left == null && Right == null)
            {
                Data = data;
            }
            else if (Data != null && Left == null && Right == null)
            {
                Left = new BinaryTree<T>();
                Right = new BinaryTree<T>();
                Left.Insert(Data);
                Right.Insert(data);
                Data = null;
            }
            else if (Data == null && Left != null && Right != null)
            {
                if (_isLeft)
                {
                    Left.Insert(data);
                }
                else
                {
                    Right.Insert(data);
                }
                _isLeft = !_isLeft;
            }
        }

        public void InsertDuringTournament(T data, int indexGladiator, int level, int compValue) // use index from table
        {
            if (Data != null)
            {
                return;
            }
            else if (Data == null && (Left.Data == data || Right.Data == data))
            {
                Data = data;
                return;
            }
            else if (Left == null || Right == null)
            {
                return;
            }
            
            else
            {
                compValue = compValue / 2;
                if (indexGladiator < level)
                {
                    level = level - compValue;
                    Left.InsertDuringTournament(data, indexGladiator, level, compValue);

                }
                else
                {
                    level += compValue;
                    Right.InsertDuringTournament(data, indexGladiator, level, compValue);
                }
            }
        }

        public List<T> GetPairToFight(int indexGladiator, int level, int compValue)
        {
            _pairToCompetition.Clear();
            if (Data != null)
            {
                _pairToCompetition.Add(Data);

                return _pairToCompetition;
            }
            else if (Data == null && Left.Data != null && Right.Data != null)
            {
                _pairToCompetition.Add(Left.Data);
                _pairToCompetition.Add(Right.Data);

                return _pairToCompetition;
            }
            else if (Left == null && Right == null)
            {
                return null;
            }
            else
            {
                compValue = compValue / 2;
                if (indexGladiator < level)
                {
                    
                    level = level - compValue;
                    _pairToCompetition = Left.GetPairToFight(indexGladiator, level, compValue);

                }
                else
                {
                    level += compValue;
                    _pairToCompetition = Right.GetPairToFight(indexGladiator, level, compValue);
                }
            }
            return _pairToCompetition;
        }
        public T GetChampion()
        {
            if (Data != null)
            {
                return Data;
            }
            return null;
        }

    }
}

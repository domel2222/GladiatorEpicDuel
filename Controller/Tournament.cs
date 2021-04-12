using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorEpicDuels
{
    public class Tournament
    {


        private List<List<BaseGladiator>> _actualStageList { get; set; } = new List<List<BaseGladiator>>();
        private List<List<BaseGladiator>> _startListOfParticipants { get; set; }
        
        private  BinaryTree<BaseGladiator> _tournamentsTree { get; set; }

        private List<int> _listWithStartPosition { get; set; } = new List<int>();

        private const int  _startLoop = 0;
        public  List<BaseGladiator> PairToFight { get; private set; }
        public Tournament(List<List<BaseGladiator>> listofpair)
        {
            _startListOfParticipants = listofpair;
            _actualStageList = listofpair.ToList();
            CreateTournamentTree();
            AddAllGladiators();
        }
        
        private  void CreateTournamentTree()
        {
             _tournamentsTree = new BinaryTree<BaseGladiator>(); 
        }

        public void AddOneWinner(BaseGladiator gladiator)
        {
            var indexGladiator = GetIndexPairOfGladiators(gladiator);

            var level = GetActualStageOfTournament();
            var compVal = GetActualStageOfTournament();
            _tournamentsTree.InsertDuringTournament(gladiator, indexGladiator, level, compVal);
        }

        public void SetPairToFight(int indexGladiator)
        {
            var level = GetActualStageOfTournament();
            var compVal = GetActualStageOfTournament();
            PairToFight =  _tournamentsTree.GetPairToFight(indexGladiator, level, compVal);
        }

        public string GetChampion()
        {
            var winner = _tournamentsTree.GetChampion();

            return ($"WE HAVE THE WINNER {winner.FullName}" );
        }
        public void SetActualStageList(List<List<BaseGladiator>> listofpair)
        {
            _actualStageList = listofpair.ToList();
        }
        private void AddAllGladiators()
        {
            _listWithStartPosition.Clear();
            _listWithStartPosition.Add(_startLoop);
            var amoutPairOfParticipants = _startListOfParticipants.Count();
        
            if (amoutPairOfParticipants == 1 || amoutPairOfParticipants == 2)
            {
                for (int i = 0; i < amoutPairOfParticipants; i++)
                {
                    _tournamentsTree.Insert(_startListOfParticipants[i][0]);
                }
                for (int i = 0; i < amoutPairOfParticipants; i++)
                {
                    _tournamentsTree.Insert(_startListOfParticipants[i][1]);
                }
                return;
            }
            var helperLoopValue = CalculateHelepLoopValue(amoutPairOfParticipants);

            var loopPlus = amoutPairOfParticipants / 2;

            if (amoutPairOfParticipants > 7)
            {
                _listWithStartPosition = Utilities.CreatePatternListToLocation(_listWithStartPosition, helperLoopValue);
            }
            foreach (var item in _listWithStartPosition)
            {
                int start = item;
                while (start < loopPlus)
                {

                    for (int i = start; i < amoutPairOfParticipants; i += loopPlus)
                    {
                        _tournamentsTree.Insert(_startListOfParticipants[i][0]);
                    }
                    start += helperLoopValue;
                }
            }
            foreach (var item in _listWithStartPosition)
            {
                int start = item;
                while (start < loopPlus)
                {

                    for (int i = start; i < amoutPairOfParticipants; i += loopPlus)
                    {
                        _tournamentsTree.Insert(_startListOfParticipants[i][1]);
                    }
                    start += helperLoopValue;
                }
            }
        }
        private int GetIndexPairOfGladiators(BaseGladiator gladiator)
        {
            return _actualStageList.FindIndex(pair => pair.Contains(gladiator));
        }

        private int GetActualStageOfTournament()
        {
            return _actualStageList.Count() / 2;
        }

        private int CalculateHelepLoopValue( int amoutOfPartcipants)
        {
            int helperLoopValue = 0;
            if (amoutOfPartcipants > 8)
            {
                helperLoopValue = amoutOfPartcipants / 4;
            }
            else if (amoutOfPartcipants == 8)
            {
                helperLoopValue = 2;
            }
            else if(amoutOfPartcipants == 4)
            {
                helperLoopValue = 1;
            }
            return helperLoopValue;
        }
    }
}

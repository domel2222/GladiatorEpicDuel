using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GladiatorEpicDuels
{
    public class Colosseum
    {

        private GladiatorFactory _factory;

        private int _numberOfContestants { get; set; }
        private List<BaseGladiator> _shuffleGladiatorsList { get; set; }

        private List<BaseGladiator> _actualParticipant = new List<BaseGladiator>();

        private Tournament _tournament { get; set; }
        private List<List<BaseGladiator>> _listOfPair { get; set; } = new List<List<BaseGladiator>>();

        private IView _view;
        public Colosseum(int amoutGladiators, GladiatorFactory factory)
        {
            _factory = factory;
            _numberOfContestants = amoutGladiators;
        }

        private int countFight = 0;
        public void IsAGameThereAreVictims()
        {
            CreateListOfContesants();
            SplitGladiatorsIntoPairs();
            CreateTournament(_listOfPair);
        }
        public void SetView(IView view)
        {
            _view = view;

        }
        public void LetsGetReadyToRumble()
        {
            while (_actualParticipant.Count() > 1)
            {
                _actualParticipant.Clear();
                for (int i = 0; i < HowManyRoundInStage(); i++)
                {
                    _tournament.SetPairToFight(i);
                    var pairToFight = _tournament.PairToFight;
                    var winner = SimulationCombat(pairToFight);
                    _tournament.AddOneWinner(winner);
                    _actualParticipant.Add(winner);countFight++;
                    
                }
                _listOfPair.Clear();
                SplitGladiatorsIntoPairs();
                _tournament.SetActualStageList(_listOfPair);
            }
            _view.Display(_tournament.GetChampion());

        }


        private void CreateTournament(List<List<BaseGladiator>>  listOfPair)
        {
            _tournament = new Tournament(listOfPair);
        }

        private void CreateListOfContesants()
        {
            _shuffleGladiatorsList = _factory.CreateGladiatrosWhatAmountYouWant(_numberOfContestants);
            _shuffleGladiatorsList.Shuffle();
            _actualParticipant = _shuffleGladiatorsList.ToList();
        }

        private void SplitGladiatorsIntoPairs()
        {
            var listOfpair = Utilities.Chunk(_actualParticipant, 2).ToList();

            foreach (var pair in listOfpair)
            {
                _listOfPair.Add((List<BaseGladiator>)pair);
            }
        }

        private BaseGladiator SimulationCombat(List<BaseGladiator> listGladiators)
        {
            Console.Clear();
            
            _view.Display(StringStageIntroduction());
            var first = listGladiators[0];
            var second = listGladiators[1];
            var introToBattle = (IndroduceGladiators(first, second));
            _view.Display(introToBattle);
            var combat = new Combat(listGladiators);
            var winner = combat.SimulationCombat();
            var logs = combat.GetListOfLogs();
            Thread.Sleep(400);
            _view.Display(logs);//jeden display agregować 
            Thread.Sleep(400);

            return winner;
        }

        private int HowManyRoundInStage()
        {
            return _listOfPair.Count();
        }

        private string StringStageIntroduction()
        {
            string round = "";
            var stage = HowManyRoundInStage();
            if (stage > 4)
            {
                round = "elimination round";
                
            }
            else if (stage == 4)
            {
                round = "quarter-final";
                
            }
            else if (stage == 2)
            {
                round = "semi-final";
                
            }
            else if (stage == 1)
            {
                round = "final";
                
            }
            return $"Welcome to the colosseum in {round}.\nThe next fight they will fight \n";
        }
        private StringBuilder IndroduceGladiators(BaseGladiator first, BaseGladiator second)
        {
            StringBuilder intro = new StringBuilder();

            intro.AppendLine($"Duel {first.FullName} versus {second.FullName}");
            intro.AppendLine("***************************************************************************************");
            intro.AppendLine($"{first.ToString()} ({first.CurrentHp}\\{first.CurrentHp} HP, {first.Speed} SP, {first.Dexterity} DEX, {first.Level} LV)");
            intro.AppendLine("***************************************************************************************");
            intro.AppendLine($"{second.ToString()} ({second.CurrentHp}\\{second.CurrentHp} HP, {second.Speed} SP, {second.Dexterity} DEX, {second.Level} LV)");

            return intro;
        }
    }
}



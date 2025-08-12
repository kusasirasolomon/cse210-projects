namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _requiredTimes;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonusPoints)
            : base(name, description, points)
        {
            _timesCompleted = 0;
            _requiredTimes = requiredTimes;
            _bonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            if (_timesCompleted < _requiredTimes)
            {
                _timesCompleted++;
                if (_timesCompleted == _requiredTimes)
                {
                    return Points + _bonusPoints;
                }
                else
                {
                    return Points;
                }
            }
            return 0;
        }

        public override bool IsComplete() => _timesCompleted >= _requiredTimes;

        public override string GetStatus()
            => $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) Completed {_timesCompleted}/{_requiredTimes}";

        public override string Serialize()
            => $"ChecklistGoal|{Name}|{Description}|{Points}|{_timesCompleted}|{_requiredTimes}|{_bonusPoints}";

        public static ChecklistGoal Deserialize(string[] parts)
        {
            var goal = new ChecklistGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                int.Parse(parts[5]),
                int.Parse(parts[6])
            );
            goal._timesCompleted = int.Parse(parts[4]);
            return goal;
        }
    }
}

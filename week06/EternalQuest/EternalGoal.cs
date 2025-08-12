namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            // Always earn points; never complete
            return Points;
        }

        public override bool IsComplete() => false;

        public override string GetStatus()
            => $"[∞] {Name} ({Description})";

        public override string Serialize()
            => $"EternalGoal|{Name}|{Description}|{Points}";
        
        public static EternalGoal Deserialize(string[] parts)
        {
            return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
        }
    }
}

using System;
using System.Threading.Tasks;

namespace SeaAdventure
{
    // Class representing the sea captain
    class SeaCaptain
    {
        public string Name { get; set; }
        public int ShipHealth { get; set; }

        // Constructor to initialize captain's name and ship health
        public SeaCaptain(string name)
        {
            Name = name;
            ShipHealth = 100;
        }

        // Method to display ship's health
        public void DisplayShipHealth()
        {
            Console.WriteLine($"Captain {Name}, Ship's Hull Integrity: {ShipHealth}");
        }
    }

    // Class representing the sea adventure
    class SeaAdventure
    {
        // Method to simulate encounters with enemy ships
        public async Task<int> Encounter(SeaCaptain captain)
        {
            // Simulate encounters with a delay
            await Task.Delay(1500);
            Random rand = new Random();
            int enemyDamage = rand.Next(10, 25); // Random damage between 10 and 25
            captain.ShipHealth -= enemyDamage;
            return enemyDamage; // Return the damage dealt
        }

        // Method to simulate repairing the ship during battle
        public void Repair(SeaCaptain captain)
        {
            // Simulate repair with a delay
            Console.WriteLine("Calling Ship Engineers for Repairs...");
            Task.Delay(2000).Wait(); // Wait for repair action
            captain.ShipHealth += 20; // Restore 20 hull integrity points
            Console.WriteLine("Ship's hull integrity restored slightly!");
        }
    }

    class Program
    {
        // Main function
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Sea Adventure Game!");

            // Create a new sea captain
            Console.Write("Enter your Captain's Name: ");
            string captainName = Console.ReadLine();
            SeaCaptain captain = new SeaCaptain(captainName);

            SeaAdventure seaAdventure = new SeaAdventure();

            // Adventure loop
            while (captain.ShipHealth > 0)
            {
                // Display ship's health
                captain.DisplayShipHealth();

                // Simulate an encounter
                Console.WriteLine("Sailing into Uncharted Waters...");
                int enemyDamage = await seaAdventure.Encounter(captain);
                Console.WriteLine($"Your ship took {enemyDamage} damage!");

                // Check if captain's ship's health dropped to 0 or below
                if (captain.ShipHealth <= 0)
                {
                    Console.WriteLine("Game Over! Your Ship has been Sunk.");
                    break;
                }

                // Ask the captain if they want to repair or continue the adventure
                Console.Write("Do you want to call for Ship Engineers to repair the ship? (yes/no): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "yes")
                {
                    seaAdventure.Repair(captain);
                }

                // Ask the captain if they want to continue the adventure
                Console.Write("Do you want to continue the adventure? (yes/no): ");
                choice = Console.ReadLine();
                if (choice.ToLower() != "yes")
                {
                    Console.WriteLine("Heading back to Port...");
                    break;
                }
            }

            Console.WriteLine("Thanks for being a Sea Adventurer!");
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.SolverFoundation.Solvers;

//namespace Zebra
//{
//    enum HouseColour { Blue, Green, White, Red, Yellow };
//    enum Drink { Beer, Coffee, Milk, Tea, Water };
//    enum Nationality { English, Danish, German, Norwegian, Swedish };
//    enum Smoke { Blend, BlueMaster, Dunhill, PallMall, Prince };
//    enum Pet { Bird, Cat, Dog, Horse, Zebra };

//    internal class Program
//    {
//        static void Main()
//        {
//            var solver = ConstraintSystem.CreateSolver();
//            var constraints = new ZebraPuzzleConstraints(solver);
//            solver = AddConstraintsToSolver(solver, constraints);

//            var solution = solver.Solve(new ConstraintSolverParams());
//            var solutionTable = ConvertToSolutionTable(solution, constraints);

//            WriteZebraSolutionToConsole(solutionTable);
//            WriteSolutionForAllTheHousesToConsole(solutionTable);
//        }

//        private static ConstraintSystem AddConstraintsToSolver(ConstraintSystem solver, ZebraPuzzleConstraints constraints)
//        {
//            solver.AddConstraints(constraints.TheEnglishManLivesInTheRedHouse());
//            solver.AddConstraints(constraints.TheSwedeHasADog());
//            solver.AddConstraints(constraints.TheDaneDrinksTea());
//            solver.AddConstraints(constraints.TheGreenHouseIsImmediatelyToTheLeftOfTheWhiteHouse());
//            solver.AddConstraints(constraints.TheyDrinkCoffeeInTheGreenHouse());
//            solver.AddConstraints(constraints.TheManWhoSmokesPallMallHasBirds());
//            solver.AddConstraints(constraints.InTheYellowHouseTheySmokeDunhill());
//            solver.AddConstraints(constraints.InTheMiddleHouseTheyDrinkMilk());
//            solver.AddConstraints(constraints.TheNorwegianLivesInTheFirstHouse());
//            solver.AddConstraints(constraints.TheManWhoSmokesBlendLivesInTheHouseNextToTheHouseWithCats());
//            solver.AddConstraints(constraints.InAHouseNextToTheHouseWhereTheyHaveAHorseTheySmokeDunhill());
//            solver.AddConstraints(constraints.TheManWhoSmokesBlueMasterDrinksBeer());
//            solver.AddConstraints(constraints.TheGermanSmokesPrince());
//            solver.AddConstraints(constraints.TheNorwegianLivesNextToTheBlueHouse());
//            solver.AddConstraints(constraints.TheyDrinkWaterInAHouseNextToTheHouseWhereTheySmokeBlend());

//            return solver;
//        }

//        private static SolutionTable ConvertToSolutionTable(ConstraintSolverSolution solution, ZebraPuzzleConstraints constraints)
//        {
//            return new SolutionTable(constraints.HouseNumbers.Select(houseNumber => new SolutionRow
//                (
//                    houseNumber + 1, 
//                    (HouseColour)DetermineTermFromSolution(solution, constraints.ColourMatrix, houseNumber, constraints.HouseNumbers), 
//                    (Drink)DetermineTermFromSolution(solution, constraints.DrinkMatrix, houseNumber, constraints.HouseNumbers), 
//                    (Nationality)DetermineTermFromSolution(solution, constraints.NationalityMatrix, houseNumber, constraints.HouseNumbers), 
//                    (Smoke)DetermineTermFromSolution(solution, constraints.SmokeMatrix, houseNumber, constraints.HouseNumbers), 
//                    (Pet)DetermineTermFromSolution(solution, constraints.PetMatrix, houseNumber, constraints.HouseNumbers)
//                )).ToList());
//        }

//        private static void WriteZebraSolutionToConsole(SolutionTable solution)
//        {
//            var ownerNationality = solution.Rows
//                .Where(row => row.Pet.Equals(Pet.Zebra))
//                .Select(owner => owner.Nationality).Single();

//            Console.WriteLine("The {0} owns the Zebra.{1}", ownerNationality, Environment.NewLine);
//        }

//        private static void WriteSolutionForAllTheHousesToConsole(SolutionTable solution)
//        {
//            Console.WriteLine("House Colour Drink  Nationality Smokes     Pet");
//            Console.WriteLine("───── ────── ────── ─────────── ────────── ─────");
//            solution.Rows.ForEach(row => Console.WriteLine("{0,5} {1,-6} {2,-6} {3,-11} {4,-10} {5,-10}", 
//                row.HouseNumber, row.HouseColour, row.Drink, row.Nationality, row.Smoke, row.Pet));
//        }

//        static int DetermineTermFromSolution(ConstraintSolverSolution solution, CspTerm[][] terms, int currentHouseNumber, IEnumerable<int> houseNubmers)
//        {
//            if (solution == null) throw new ArgumentNullException("solution");
//            if (terms == null) throw new ArgumentNullException("terms");

//            foreach (var houseNumber in houseNubmers)
//            {
//                object term;
//                solution.TryGetValue(terms[currentHouseNumber][houseNumber], out term);

//                if ((int)term == 1)
//                    return houseNumber;
//            }
//            return 0;
//        }
//    }

//    internal class SolutionTable
//    {
//        public SolutionTable(List<SolutionRow> rows)
//        {
//            Rows = rows;
//        }

//        public List<SolutionRow> Rows { get; private set; }
//    }

//    class SolutionRow
//    {
//        public SolutionRow(int houseNumber, HouseColour houseColor, Drink drink, Nationality nationality, Smoke smoke, Pet pet)
//        {
//            HouseNumber = houseNumber;
//            HouseColour = houseColor;
//            Drink = drink;
//            Nationality = nationality;
//            Smoke = smoke;
//            Pet = pet;
//        }

//        public int HouseNumber { get; private set; }
//        public HouseColour HouseColour { get; private set; }
//        public Drink Drink { get; private set; }
//        public Nationality Nationality { get; private set; }
//        public Smoke Smoke { get; private set; }
//        public Pet Pet { get; private set; }
//    }

//    class ZebraPuzzleConstraints
//    {
//        private CspTerm[][] CreateConstrainSystemMatrix(ConstraintSystem system)
//        {
//            var size = HouseNumbers.Count;
//            var matrix = system.CreateBooleanArray(new object(), size, size);

//            Enumerable.Range(0, size).ToList().ForEach(i =>
//            {
//                var row = system.CreateBooleanVector(new object(), size);
//                var column = system.CreateBooleanVector(new object(), size);

//                Enumerable.Range(0, size).ToList().ForEach(j =>
//                {
//                    row[j] = matrix[i][j];
//                    column[j] = matrix[j][i];
//                });

//                system.AddConstraints(system.Equal(1, system.Sum(row)));
//                system.AddConstraints(system.Equal(1, system.Sum(column)));
//            });

//            return matrix;
//        }

//        public List<int> HouseNumbers { get; private set; }
//        public ConstraintSystem Solver { get; private set; }
//        public CspTerm[][] ColourMatrix { get; private set; }
//        public CspTerm[][] DrinkMatrix { get; private set; }
//        public CspTerm[][] NationalityMatrix { get; private set; }
//        public CspTerm[][] SmokeMatrix { get; private set; }
//        public CspTerm[][] PetMatrix { get; private set; }

//        public ZebraPuzzleConstraints(ConstraintSystem solver)
//        {
//            Solver = solver;
//            HouseNumbers = ThereAreFiveHouses();

//            ColourMatrix = CreateConstrainSystemMatrix(Solver);
//            DrinkMatrix = CreateConstrainSystemMatrix(Solver);
//            NationalityMatrix = CreateConstrainSystemMatrix(Solver);
//            SmokeMatrix = CreateConstrainSystemMatrix(Solver);
//            PetMatrix = CreateConstrainSystemMatrix(Solver);
//        }

//        public static List<int> ThereAreFiveHouses()
//        {
//            return new List<int> { 0, 1, 2, 3, 4 };
//        }

//        public CspTerm[] TheDaneDrinksTea()
//        {
//            return HouseNumbers.Select(houseNumber => Solver.Equal(
//                Solver.Equal(DrinkMatrix[houseNumber][(int)Drink.Tea],
//                NationalityMatrix[houseNumber][(int)Nationality.Danish])))
//                .ToArray();
//        }

//        public CspTerm[] TheSwedeHasADog()
//        {
//            return HouseNumbers.Select(houseNumber => Solver.Equal(
//                PetMatrix[houseNumber][(int)Pet.Dog], 
//                NationalityMatrix[houseNumber][(int)Nationality.Swedish]))
//                .ToArray();
//        }

//        public CspTerm[] TheEnglishManLivesInTheRedHouse()
//        {
//            return HouseNumbers.Select(houseNumber => Solver.Equal(
//                ColourMatrix[houseNumber][(int) HouseColour.Red], 
//                NationalityMatrix[houseNumber][(int)Nationality.English]))
//                .ToArray();
//        }

//        public CspTerm[] TheGreenHouseIsImmediatelyToTheLeftOfTheWhiteHouse()
//        {
//            var constraints = new List<CspTerm>
//            {
//                Solver.Equal(0, ColourMatrix[0][(int) HouseColour.White]),
//                Solver.Equal(ColourMatrix[1][(int)HouseColour.White], ColourMatrix[0][(int)HouseColour.Green])
//            };

//            Enumerable.Range(1, 3).ToList()
//                .ForEach(houseNumber => constraints.Add(Solver.Equal(
//                    ColourMatrix[houseNumber + 1][(int)HouseColour.White], 
//                    ColourMatrix[houseNumber][(int)HouseColour.Green])));

//            return constraints.ToArray();
//        }

//        public CspTerm[] TheyDrinkCoffeeInTheGreenHouse()
//        {
//             return HouseNumbers.Select(houseNumber => Solver.Equal(
//                 DrinkMatrix[houseNumber][(int)Drink.Coffee], 
//                 ColourMatrix[houseNumber][(int)HouseColour.Green]))
//                 .ToArray();
//        }

//        public CspTerm[] TheManWhoSmokesPallMallHasBirds()
//        {
//            return HouseNumbers.Select(houseNumber => Solver.Equal(
//                SmokeMatrix[houseNumber][(int)Smoke.PallMall], 
//                PetMatrix[houseNumber][(int)Pet.Bird]))
//                .ToArray();
//        }

//        public CspTerm[] InTheYellowHouseTheySmokeDunhill()
//        {
//            return HouseNumbers.Select(houseNumber => Solver.Equal(
//                SmokeMatrix[houseNumber][(int)Smoke.Dunhill], 
//                ColourMatrix[houseNumber][(int)HouseColour.Yellow]))
//                .ToArray();
//        }

//        public CspTerm[] InTheMiddleHouseTheyDrinkMilk()
//        {
//            const int middleHouseNumber = 2;
//            return new []
//            {
//                Solver.Equal(1, DrinkMatrix[middleHouseNumber][(int) Drink.Milk])
//            };
//        }

//        public CspTerm[] TheManWhoSmokesBlendLivesInTheHouseNextToTheHouseWithCats()
//        {
//            var constraints = new List<CspTerm>
//            {
//                Solver.Greater(1, Solver.Sum(
//                    SmokeMatrix[0][(int) Smoke.Blend],
//                    PetMatrix[0][(int) Pet.Cat]) - Solver.Sum(
//                        SmokeMatrix[1][(int) Smoke.Blend],
//                        PetMatrix[1][(int) Pet.Cat])), 

//                 Solver.Greater(1, Solver.Sum(
//                    SmokeMatrix[4][(int)Smoke.Blend],
//                    PetMatrix[4][(int)Pet.Cat]) - Solver.Sum(
//                        SmokeMatrix[3][(int)Smoke.Blend],
//                        PetMatrix[3][(int)Pet.Cat]))
//            };

//            Enumerable.Range(1, 3).ToList()
//                .ForEach(houseNumber => constraints.Add(Solver.Greater(1, Solver.Sum(
//                    SmokeMatrix[houseNumber][(int) Smoke.Blend],
//                    PetMatrix[houseNumber][(int) Pet.Cat]) - Solver.Sum(
//                        SmokeMatrix[houseNumber - 1][(int) Smoke.Blend],
//                        SmokeMatrix[houseNumber + 1][(int) Smoke.Blend],
//                        PetMatrix[houseNumber - 1][(int) Pet.Cat],
//                        PetMatrix[houseNumber + 1][(int) Pet.Cat]))));

//            return constraints.ToArray();
//        }

//        public CspTerm[] TheManWhoSmokesBlueMasterDrinksBeer()
//        {
//            return HouseNumbers.Select(houseNumber => Solver.Equal(
//                SmokeMatrix[houseNumber][(int)Smoke.BlueMaster], 
//                DrinkMatrix[houseNumber][(int)Drink.Beer]))
//                .ToArray();
//        }

//        public CspTerm[] TheGermanSmokesPrince()
//        {
//            return HouseNumbers.Select(houseNumber => Solver.Equal(
//                SmokeMatrix[houseNumber][(int)Smoke.Prince], 
//                NationalityMatrix[houseNumber][(int)Nationality.German]))
//                .ToArray();
//        }

//        public CspTerm TheNorwegianLivesInTheFirstHouse()
//        {
//            const int firstHouseNumber = 0;
//            return Solver.Equal(1, NationalityMatrix[firstHouseNumber][(int)Nationality.Norwegian]);
//        }

//        public CspTerm[] TheNorwegianLivesNextToTheBlueHouse()
//        {
//            var constraints = new List<CspTerm>
//            {
//                Solver.Greater(1, Solver.Sum(
//                    NationalityMatrix[0][(int) Nationality.Norwegian],
//                    ColourMatrix[0][(int) HouseColour.Blue]) - Solver.Sum(
//                        NationalityMatrix[1][(int) Nationality.Norwegian],
//                        ColourMatrix[1][(int) HouseColour.Blue])),

//                Solver.Greater(1, Solver.Sum(
//                    NationalityMatrix[4][(int) Nationality.Norwegian],
//                    ColourMatrix[4][(int) HouseColour.Blue]) - Solver.Sum(
//                        NationalityMatrix[3][(int) Nationality.Norwegian],
//                        ColourMatrix[3][(int) HouseColour.Blue]))
//            };

//            Enumerable.Range(1, 3).ToList()
//                .ForEach(houseNumber => constraints.Add(Solver.Greater(1, Solver.Sum(
//                    NationalityMatrix[houseNumber][(int) Nationality.Norwegian],
//                    ColourMatrix[houseNumber][(int) HouseColour.Blue]) - Solver.Sum(
//                        NationalityMatrix[houseNumber - 1][(int) Nationality.Norwegian],
//                        NationalityMatrix[houseNumber + 1][(int) Nationality.Norwegian],
//                        ColourMatrix[houseNumber - 1][(int) HouseColour.Blue],
//                        ColourMatrix[houseNumber + 1][(int) HouseColour.Blue]))));

//                return constraints.ToArray();
//        }

//        public CspTerm[] TheyDrinkWaterInAHouseNextToTheHouseWhereTheySmokeBlend()
//        {
//            var constraints = new List<CspTerm>
//            {
//             Solver.Greater(1, Solver.Sum(
//                SmokeMatrix[4][(int)Smoke.Blend],
//                DrinkMatrix[4][(int)Drink.Water]) - Solver.Sum(
//                    SmokeMatrix[3][(int)Smoke.Blend],
//                    DrinkMatrix[3][(int)Drink.Water])), 

//                Solver.Greater(1, Solver.Sum(
//                SmokeMatrix[0][(int)Smoke.Blend],
//                DrinkMatrix[0][(int)Drink.Water]) - Solver.Sum(
//                    SmokeMatrix[1][(int)Smoke.Blend],
//                    DrinkMatrix[1][(int)Drink.Water]))
//            };

//            Enumerable.Range(1, 3).ToList()
//                .ForEach(houseNumber => constraints.Add(Solver.Greater(1, Solver.Sum(
//                SmokeMatrix[houseNumber][(int) Smoke.Blend],
//                DrinkMatrix[houseNumber][(int) Drink.Water]) - Solver.Sum(
//                    SmokeMatrix[houseNumber - 1][(int) Smoke.Blend],
//                    SmokeMatrix[houseNumber + 1][(int) Smoke.Blend],
//                    DrinkMatrix[houseNumber - 1][(int) Drink.Water],
//                    DrinkMatrix[houseNumber + 1][(int) Drink.Water]))));

//            return constraints.ToArray();
//        }

//        public CspTerm[] InAHouseNextToTheHouseWhereTheyHaveAHorseTheySmokeDunhill()
//        {
//            var constraints = new List<CspTerm>
//            {
//                Solver.Greater(1, Solver.Sum(
//                    SmokeMatrix[0][(int) Smoke.Dunhill],
//                    PetMatrix[0][(int) Pet.Horse]) - Solver.Sum(
//                        SmokeMatrix[1][(int) Smoke.Dunhill],
//                        PetMatrix[1][(int) Pet.Horse])),

//                Solver.Greater(1, Solver.Sum(
//                    SmokeMatrix[4][(int) Smoke.Dunhill],
//                    PetMatrix[4][(int) Pet.Horse]) - Solver.Sum(
//                        SmokeMatrix[3][(int) Smoke.Dunhill],
//                        PetMatrix[3][(int) Pet.Horse]))
//            };

//            Enumerable.Range(1, 3).ToList()
//                .ForEach(houseNumber => constraints.Add(Solver.Greater(1, Solver.Sum(
//                    SmokeMatrix[houseNumber][(int) Smoke.Dunhill],
//                    PetMatrix[houseNumber][(int) Pet.Horse]) - Solver.Sum(
//                        SmokeMatrix[houseNumber - 1][(int) Smoke.Dunhill],
//                        SmokeMatrix[houseNumber + 1][(int) Smoke.Dunhill],
//                        PetMatrix[houseNumber - 1][(int) Pet.Horse],
//                        PetMatrix[houseNumber + 1][(int) Pet.Horse]))));

//            return constraints.ToArray();
//        }
//    }
//}


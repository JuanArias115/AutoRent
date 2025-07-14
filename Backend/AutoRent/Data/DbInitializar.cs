using AutoRent.Models;

namespace AutoRent.Data
{
    public class DbInitializar
    {
        public static async Task initializeSeed(AutoRentDbContext context)
        {
            if (!context.Cars.Any())
            {
                await context.Cars.AddRangeAsync(new List<Car>
                {
                    new Car
                    {
                        Brand = "Toyota",
                        Model = "Corolla",
                        PlateNumber = "ABC-1234",
                        Year = 2022,
                        CurrentKm = 25000,
                        ImageUrl = "https://autonotizen.de/images/t/o/y/o/t/toyota-corolla-modelljahr-2022toyota-corolla-2022-modellpflege-hatch-front1638035858-fd825aa1.jpg",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 200,
                        kmPenaltyFee = 0.25,
                        dailyPrice = 45.00,
                        dailyPenaltyFee = 10.00,
                        unlimitedKmFee = 15.00
                    },
                    new Car
                    {
                        Brand = "Honda",
                        Model = "Civic",
                        PlateNumber = "DEF-5678",
                        Year = 2021,
                        CurrentKm = 30000,
                        ImageUrl = "https://di-honda-enrollment.s3.amazonaws.com/2021/model-pages/civic_hatchback/trims/Hatchback+Sport+Touring.jpg",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 200,
                        kmPenaltyFee = 0.25,
                        dailyPrice = 47.50,
                        dailyPenaltyFee = 10.00,
                        unlimitedKmFee = 15.00
                    },
                    new Car
                    {
                        Brand = "Ford",
                        Model = "Focus",
                        PlateNumber = "GHI-9012",
                        Year = 2023,
                        CurrentKm = 15000,
                        ImageUrl = "https://www.ford.de/content/dam/guxeu/rhd/central/cars/2021-focus/dse/column-cards/ford-focus-eu-Column_Card_Focus-Active-X-3x2-1000x667-chrome-blue-front-view.jpg",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Manual",
                        kmDay = 200,
                        kmPenaltyFee = 0.20,
                        dailyPrice = 42.00,
                        dailyPenaltyFee = 8.00,
                        unlimitedKmFee = 12.00
                    },
                    new Car
                    {
                        Brand = "Volkswagen",
                        Model = "Golf",
                        PlateNumber = "JKL-3456",
                        Year = 2022,
                        CurrentKm = 20000,
                        ImageUrl = "https://p.turbosquid.com/ts-thumb/E1/Opgkou/wF/volkswagen_golf_r_2022_0000/jpg/1644245306/600x600/fit_q87/c491fa06e583a32c470344f048745bc9895e60b4/volkswagen_golf_r_2022_0000.jpg",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Diesel",
                        transmission = "Automatic",
                        kmDay = 250,
                        kmPenaltyFee = 0.30,
                        dailyPrice = 50.00,
                        dailyPenaltyFee = 12.00,
                        unlimitedKmFee = 18.00
                    },
                    new Car
                    {
                        Brand = "Mercedes-Benz",
                        Model = "C-Class",
                        PlateNumber = "MNO-7890",
                        Year = 2024,
                        CurrentKm = 5000,
                        ImageUrl = "https://vehicle-images.dealerinspire.com/d7a7-210005944/W1KAF4HB9RR226441/5be13053a68fb4ae6d3696c7d86b4fc0.jpg",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 150,
                        kmPenaltyFee = 0.50,
                        dailyPrice = 80.00,
                        dailyPenaltyFee = 20.00,
                        unlimitedKmFee = 30.00
                    },
                    new Car
                    {
                        Brand = "BMW",
                        Model = "3 Series",
                        PlateNumber = "PQR-1122",
                        Year = 2023,
                        CurrentKm = 10000,
                        ImageUrl = "https://vehicle-images.dealerinspire.com/stock-images/thumbnails/large/chrome/aebcedfcdc8347721ba2c7d1eb8ffd97.png",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Diesel",
                        transmission = "Automatic",
                        kmDay = 150,
                        kmPenaltyFee = 0.50,
                        dailyPrice = 75.00,
                        dailyPenaltyFee = 20.00,
                        unlimitedKmFee = 30.00
                    },
                    new Car
                    {
                        Brand = "Audi",
                        Model = "A4",
                        PlateNumber = "STU-3344",
                        Year = 2022,
                        CurrentKm = 18000,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDtrxkrU4nFKWHaATekNAc0wpzehMvPvFOlQ&s",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 150,
                        kmPenaltyFee = 0.45,
                        dailyPrice = 70.00,
                        dailyPenaltyFee = 18.00,
                        unlimitedKmFee = 28.00
                    },
                    new Car
                    {
                        Brand = "Toyota",
                        Model = "RAV4",
                        PlateNumber = "VWX-5566",
                        Year = 2023,
                        CurrentKm = 12000,
                        ImageUrl = "https://toyotacanada.scene7.com/is/image/toyotacanada/FINAL2023_RAV4_WoodlandEdition_001?ts=1688694631428&$Media-Large$&dpr=off",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Hybrid",
                        transmission = "Automatic",
                        kmDay = 200,
                        kmPenaltyFee = 0.35,
                        dailyPrice = 60.00,
                        dailyPenaltyFee = 15.00,
                        unlimitedKmFee = 25.00
                    },
                    new Car
                    {
                        Brand = "Honda",
                        Model = "CR-V",
                        PlateNumber = "YZA-7788",
                        Year = 2022,
                        CurrentKm = 22000,
                        ImageUrl = "https://cdn.wheel-size.com/automobile/body/honda-cr-v-2022-2025-1716542345.55664.jpg",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 200,
                        kmPenaltyFee = 0.35,
                        dailyPrice = 58.00,
                        dailyPenaltyFee = 14.00,
                        unlimitedKmFee = 24.00
                    },
                    new Car
                    {
                        Brand = "Ford",
                        Model = "Kuga",
                        PlateNumber = "BCD-9900",
                        Year = 2024,
                        CurrentKm = 8000,
                        ImageUrl = "https://www.meinauto.de/pics/auto_neuwagen/ford-kuga-2024.png",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Diesel",
                        transmission = "Automatic",
                        kmDay = 200,
                        kmPenaltyFee = 0.30,
                        dailyPrice = 55.00,
                        dailyPenaltyFee = 13.00,
                        unlimitedKmFee = 22.00
                    },
                    new Car
                    {
                        Brand = "Volkswagen",
                        Model = "T-Roc",
                        PlateNumber = "EFG-1122",
                        Year = 2023,
                        CurrentKm = 14000,
                        ImageUrl = "https://cdn1.leasing.com/cms/t-roc-life.jpg",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Manual",
                        kmDay = 200,
                        kmPenaltyFee = 0.28,
                        dailyPrice = 52.00,
                        dailyPenaltyFee = 11.00,
                        unlimitedKmFee = 20.00
                    },
                    new Car
                    {
                        Brand = "Mercedes-Benz",
                        Model = "GLC",
                        PlateNumber = "HIJ-3344",
                        Year = 2024,
                        CurrentKm = 6000,
                        ImageUrl = "https://i.3dmodels.org/uploads/Mercedes-Benz/521_Mercedes-Benz_GLC-class_Mk2_X254_Avantgarde_Line_2022/Mercedes-Benz_GLC-class_Mk2_X254_Avantgarde_Line_2022_1000_0001.jpg",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Diesel",
                        transmission = "Automatic",
                        kmDay = 150,
                        kmPenaltyFee = 0.60,
                        dailyPrice = 90.00,
                        dailyPenaltyFee = 25.00,
                        unlimitedKmFee = 35.00
                    },
                    new Car
                    {
                        Brand = "BMW",
                        Model = "X5",
                        PlateNumber = "KLM-5566",
                        Year = 2023,
                        CurrentKm = 9000,
                        ImageUrl = "https://mystrongad.com/BOL-BMWofLynchburg/Interactive/X5/2023/CAR%20CUTS/23-BMW-X5-Carbon-Black-Metallic.png",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Hybrid",
                        transmission = "Automatic",
                        kmDay = 150,
                        kmPenaltyFee = 0.70,
                        dailyPrice = 100.00,
                        dailyPenaltyFee = 30.00,
                        unlimitedKmFee = 40.00
                    },
                    new Car
                    {
                        Brand = "Audi",
                        Model = "Q5",
                        PlateNumber = "NOP-7788",
                        Year = 2022,
                        CurrentKm = 17000,
                        ImageUrl = "https://cars.usnews.com/static/images/Auto/izmo/i159614801/2022_audi_q5_angularfront.jpg",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 150,
                        kmPenaltyFee = 0.65,
                        dailyPrice = 95.00,
                        dailyPenaltyFee = 28.00,
                        unlimitedKmFee = 38.00
                    },
                    new Car
                    {
                        Brand = "Tesla",
                        Model = "Model 3",
                        PlateNumber = "QRS-9900",
                        Year = 2023,
                        CurrentKm = 11000,
                        ImageUrl = "https://img.autobytel.com/chrome/colormatched_01/white/1280/cc_2023tsc03_01_1280/cc_2023tsc030003_01_1280_msmet.jpg",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Electric",
                        FuelType = "Electric",
                        transmission = "Automatic",
                        kmDay = 300,
                        kmPenaltyFee = 0.40,
                        dailyPrice = 85.00,
                        dailyPenaltyFee = 20.00,
                        unlimitedKmFee = 30.00
                    },
                    new Car
                    {
                        Brand = "Hyundai",
                        Model = "Tucson",
                        PlateNumber = "TUV-1122",
                        Year = 2022,
                        CurrentKm = 28000,
                        ImageUrl = "https://p.turbosquid.com/ts-thumb/zr/UDuSNQ/ORmYmyeF/hyundai_tucson_2022_0000/jpg/1605178901/600x600/fit_q87/c4d63b08743588bb2b77cd9468ef2744917423f7/hyundai_tucson_2022_0000.jpg",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 200,
                        kmPenaltyFee = 0.25,
                        dailyPrice = 48.00,
                        dailyPenaltyFee = 10.00,
                        unlimitedKmFee = 16.00
                    },
                    new Car
                    {
                        Brand = "Kia",
                        Model = "Sportage",
                        PlateNumber = "WXY-3344",
                        Year = 2023,
                        CurrentKm = 16000,
                        ImageUrl = "https://vehicle-images.dealerinspire.com/stock-images/thumbnails/large/chrome/13cd740290fde904797544f0c0dd0a9d.png",
                        Doors = 5,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Diesel",
                        transmission = "Manual",
                        kmDay = 200,
                        kmPenaltyFee = 0.28,
                        dailyPrice = 50.00,
                        dailyPenaltyFee = 11.00,
                        unlimitedKmFee = 18.00
                    },
                    new Car
                    {
                        Brand = "Toyota",
                        Model = "Camry",
                        PlateNumber = "ZAB-5566",
                        Year = 2024,
                        CurrentKm = 3000,
                        ImageUrl = "https://www.buyatoyota.com/sharpr/bat/assets/img/vehicle-info/Camry/2024/hero-image.png",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Hybrid",
                        transmission = "Automatic",
                        kmDay = 250,
                        kmPenaltyFee = 0.30,
                        dailyPrice = 65.00,
                        dailyPenaltyFee = 15.00,
                        unlimitedKmFee = 25.00
                    },
                    new Car
                    {
                        Brand = "Honda",
                        Model = "Accord",
                        PlateNumber = "CDE-7788",
                        Year = 2023,
                        CurrentKm = 10000,
                        ImageUrl = "https://di-uploads-pod23.dealerinspire.com/rairdonshondaofmarysville/uploads/2021/10/2022-honda-accord-leader-1-e1635722025683.png",
                        Doors = 4,
                        Capacity = 5,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Automatic",
                        kmDay = 250,
                        kmPenaltyFee = 0.30,
                        dailyPrice = 62.00,
                        dailyPenaltyFee = 14.00,
                        unlimitedKmFee = 24.00
                    },
                    new Car
                    {
                        Brand = "Ford",
                        Model = "Fiesta",
                        PlateNumber = "FGH-9900",
                        Year = 2022,
                        CurrentKm = 35000,
                        ImageUrl = "https://www.autozeitung.de/assets/field/images/ford-fiesta-facelift-2022-01.jpg",
                        Doors = 3,
                        Capacity = 4,
                        EmissionClass = "Euro 6",
                        FuelType = "Gasoline",
                        transmission = "Manual",
                        kmDay = 150,
                        kmPenaltyFee = 0.20,
                        dailyPrice = 38.00,
                        dailyPenaltyFee = 7.00,
                        unlimitedKmFee = 10.00
                    } 
                });
            }
            await context.SaveChangesAsync();
        }
    }
}

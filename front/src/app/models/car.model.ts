export interface Car {
  id: string;
  brand: string;
  model: string;
  year: number;
  currentKm: number;
  plateNumber: string;
  isAvailable: boolean;
  imageUrl: string;
  doors: number | null;
  capacity: number | null;
  emissionClass: string | null;
  fuelType: string | null;
  transmission: string | null;
  kmDay: number ;
  kmPenaltyFee: number ;
  dailyPrice: number;
  dailyPenaltyFee: number ;
  unlimitedKmFee: number;
}
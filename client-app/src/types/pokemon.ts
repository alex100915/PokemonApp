export interface Pokemon {
  number: number;
  name: string;
  generation: string;
  height: number;
  weight: number;
  types: string[];
  stats: { name: string; value: number }[];
  moves: string[];
  abilities: string[];
  evolution: { from: string | null; to: string[] };
  image: string;
}


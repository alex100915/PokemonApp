export interface PokemonSummaryData {
  totalSpecies: number;
  typeCounts: Record<string, number>;
  generationCounts: Record<string, number>;
}

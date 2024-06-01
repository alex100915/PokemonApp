import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams, Link } from 'react-router-dom';

const PokemonDetails = () => {
  const { number } = useParams();
  const [pokemon, setPokemon] = useState(null);

  useEffect(() => {
    const fetchPokemon = async () => {
      try {
        const result = await axios.get(`https://localhost:7123/pokemon/${number}`);
        setPokemon(result.data);
      } catch (error) {
        console.error("Error fetching the Pokemon details:", error);
      }
    };

    fetchPokemon();
  }, [number]);

  if (!pokemon) return <div>Loading...</div>;

  return (
    <div>
      <h1>{pokemon.name}</h1>
      <img src={pokemon.image} alt={pokemon.name} />
      <p>Number: {pokemon.number}</p>
      <p>Generation: {pokemon.generation}</p>
      <p>Height: {pokemon.height}</p>
      <p>Weight: {pokemon.weight}</p>
      <p>Types: {pokemon.types.join(', ')}</p>
      <p>Moves: {pokemon.moves.join(', ')}</p>
      <p>Abilities: {pokemon.abilities.join(', ')}</p>
      <p>Stats:</p>
      <ul>
        {pokemon.stats.map(stat => (
          <li key={stat.name}>{stat.name}: {stat.value}</li>
        ))}
      </ul>
      {pokemon.evolution.from && (
        <p>Evolves from: <Link to={`/pokemon/${pokemon.evolution.from}`}>{pokemon.evolution.from}</Link></p>
      )}
      {pokemon.evolution.to.length > 0 && (
        <p>Evolves to: {pokemon.evolution.to.map(evo => (
          <Link key={evo} to={`/pokemon/${evo}`}>{evo}</Link>
        )).reduce((prev, curr) => [prev, ', ', curr])}</p>
      )}
    </div>
  );
};

export default PokemonDetails;

import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Dashboard = () => {
  const [pokemonData, setPokemonData] = useState([]);
  const [summaryData, setSummaryData] = useState({ total: 0, types: {}, generations: {} });
  const [page, setPage] = useState(1);

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios.get(`https://localhost:7123/pokemon?page=${page}`);
      setPokemonData(result.data);
      
      // Calculate summary data
      const total = result.data.length;
      const types = {};
      const generations = {};
      
      result.data.forEach(pokemon => {
        pokemon.types.forEach(type => {
          if (!types[type]) types[type] = 0;
          types[type]++;
        });
        
        if (!generations[pokemon.generation]) generations[pokemon.generation] = 0;
        generations[pokemon.generation]++;
      });
      
      setSummaryData({ total, types, generations });
    };
    
    fetchData();
  }, [page]);

  return (
    <div>
      <h1>Pokemon Dashboard</h1>
      <div>
        <h2>Summary</h2>
        <p>Total Pokemon: {summaryData.total}</p>
        <p>Types: {JSON.stringify(summaryData.types)}</p>
        <p>Generations: {JSON.stringify(summaryData.generations)}</p>
      </div>
      <div>
        <h2>Pokemon List</h2>
        <table>
          <thead>
            <tr>
              <th>Number</th>
              <th>Name</th>
              <th>Generation</th>
              <th>Region</th>
              <th>Height</th>
              <th>Weight</th>
              <th>Type 1</th>
              <th>Type 2</th>
              <th>Moves Count</th>
            </tr>
          </thead>
          <tbody>
            {pokemonData.map(pokemon => (
              <tr key={pokemon.number}>
                <td>{pokemon.number}</td>
                <td><a href={`/pokemon/${pokemon.number}`}>{pokemon.name}</a></td>
                <td>{pokemon.generation}</td>
                <td>{pokemon.region}</td>
                <td>{pokemon.height}</td>
                <td>{pokemon.weight}</td>
                <td>{pokemon.types[0]}</td>
                <td>{pokemon.types[1]}</td>
                <td>{pokemon.moves.length}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <div>
          <button onClick={() => setPage(page - 1)} disabled={page === 1}>Previous</button>
          <button onClick={() => setPage(page + 1)}>Next</button>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
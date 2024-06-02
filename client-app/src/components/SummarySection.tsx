import React from 'react';
import { Typography, Box, Accordion, AccordionSummary, AccordionDetails, List, ListItem, ListItemText, Paper, Grid } from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { SummaryData } from "../types/summary";

const SummarySection: React.FC<{ summary: SummaryData }> = ({ summary }) => {
  return (
    <Box mb={4}>
      <Paper elevation={3} style={{ padding: '16px' }}>
        <Typography variant="h6" gutterBottom>
          Summary
        </Typography>
        <Grid container spacing={2}>
          <Grid item xs={12} sm={6}>
            <Accordion>
              <AccordionSummary
                expandIcon={<ExpandMoreIcon />}
                aria-controls="total-species-content"
                id="total-species-header"
              >
                <Typography>Total Pokémon Species</Typography>
              </AccordionSummary>
              <AccordionDetails>
                <Typography variant="body1">
                  There are <strong>{summary.totalSpecies}</strong> Pokémon species in total.
                </Typography>
              </AccordionDetails>
            </Accordion>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Accordion>
              <AccordionSummary
                expandIcon={<ExpandMoreIcon />}
                aria-controls="type-counts-content"
                id="type-counts-header"
              >
                <Typography>Types Count</Typography>
              </AccordionSummary>
              <AccordionDetails>
                <List>
                  {Object.entries(summary.typeCounts).map(([type, count]) => (
                    <ListItem key={type}>
                      <ListItemText primary={`${type}: ${count}`} />
                    </ListItem>
                  ))}
                </List>
              </AccordionDetails>
            </Accordion>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Accordion>
              <AccordionSummary
                expandIcon={<ExpandMoreIcon />}
                aria-controls="generation-counts-content"
                id="generation-counts-header"
              >
                <Typography>Generations Count</Typography>
              </AccordionSummary>
              <AccordionDetails>
                <List>
                  {Object.entries(summary.generationCounts).map(([generation, count]) => (
                    <ListItem key={generation}>
                      <ListItemText primary={`${generation}: ${count}`} />
                    </ListItem>
                  ))}
                </List>
              </AccordionDetails>
            </Accordion>
          </Grid>
        </Grid>
      </Paper>
    </Box>
  );
};

export default SummarySection;

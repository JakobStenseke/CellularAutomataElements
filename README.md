# Cellular Automata Elements

![](CellularGIF.gif)




<a href="https://en.wikipedia.org/wiki/Cellular_automaton">Cellular automata</a> (CA) is a deeply fascinating concept. It presents proof that emergent complexity is computationally possible, i.e. that there are elements emerging from a system that require more information to be properly accounted for than the information required to run the system itself. Simply put, complexity can emerge from simplicity. Potentially our very own universe could be a program that after 13.8 billion years of runtime led to the emergence of atoms, life, and sentient creatures; phenomena vastly more complicated than the lower level phenomena generating it. Furthermore, CA can also be used to create <a href="https://en.wikipedia.org/wiki/Von_Neumann_universal_constructor">self-replicating machines</a>, and theoretically has the capacity of a Universal Turing Machine, meaning that anything that can be algorithmically computed can be computed with the use of certain CAs (such as <a href="https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)">Conway's Game of Life</a>).

This project uses a <a href="https://en.wikipedia.org/wiki/Stochastic_cellular_automaton">stochastic</a> version of CA based on a rock-paper-scissor rule. Just as in Pokémon, grass beats water, water beats fire, and fire beats grass, represented by the colors of the cells. For each epoch, the program iterates through every cell of the grid. One neighbor cell is randomly picked (1 in 8 chance of selecting a given neighbor). If the selected neighbor is empty (white) or contains a cell of the appropriate color -- e.g. red picking blue -- the selected neighbor gets occupied by the cells own color. The resulting effect is that a specific color expand their border, while another decrease. When three colors meet, interestingly the fluctuations start to resemble something lifelike.

The original goal of this project was to turn some version of cellular automata into a level based mobile game, presenting the player with the fun and puzzling challenges of generating various elements and phenomena. Unfortunately, I came to the conclusion that using conventional CAs made the game too deterministic and dull while stochastic cellular automaton would make it too unpredictable (the old <a href="https://en.wikipedia.org/wiki/Man,_Play_and_Games)">Agon vs Alea</a>, or skill vs RNG debate in game design). For anyone wanting to use CA in a game, I would recommend utilizing simpler deterministic systems rather than stochastic ones.

To start, simply click any cell in order to change its color to blue, green, or red. Press play to watch the cells battle each other out in the grid.

Additional note - Stephen Wolfram (creator of Wolfram Alpha) has studied cellular automata for decades and has made many <a href="https://en.wikipedia.org/wiki/A_New_Kind_of_Science">interesting findings</a>.

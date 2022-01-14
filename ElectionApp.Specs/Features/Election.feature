Feature: Election

@pourcentageParCandidat
Scenario: Calcul du pourcentage du scrutin pour chaque candidat
Given un premier candidat avec 75 votes
And un second candidat avec 25 votes
When le pourcentage de votes est calculé
Then le premier candidat a 75% des votes
And le second candidat a 25% des votes

@calculScrutin
Scenario: Gagner le tour du scrutin si plus de 50% des votes
Given un premier candidat avec 100 votes
And un second candidat avec 49 votes
When calcul tour du scrutin
Then le vainqueur est premier candidat 


Scenario: Pas de vainqueur au premier tour
Given aucun candidats avec plus de 50% des votes
And un scrutin au premier tour
And le scrutin est clôturé
When calcul tour du scrutin
Then le scrutin passe au deuxième tour 

Scenario: Erreur si tour de scrutin supérieur à 2 
Given le tour du scrutin égal à 3
When calcul tour du scrutin
Then un message d'erreur 'Maximum deux tours de scrutin' est affiché

Scenario: Garder les  deux meilleurs candidats si moins de 50% des votes
Given un premier candidat avec 50 votes
And un second candidat avec 49 votes
And un troisieme candidat avec 25 votes
When calcul tour du scrutin
Then les candidats du second tour sont premier candidat et second candidat

Scenario: Victoire à majorité au second tour
Given un premier candidat avec 75 voix
And un second candidat avec 25 voix
And un scrutin clôturé au second tour
When calcul tour du scrutin
Then le premier candidat est le vainqueur

Scenario: Égalité au second tour
Given un premier candidat avec 50 voix
And un second candidat avec 50 voix
And un scrutin clôturé au second tour
When calcul tour du scrutin
Then le message 'Égalité au second tour, aucun vainqueur.' est remonté 

Scenario: Erreur lors du calcul du vainqueur lorsque le scrutin n'est pas clôturé
Given un scrutin non clôturé
When calcul tour du scrutin
Then un message d'erreur 'Calcul du vainqueur impossible, le scrutin n'est pas clôturé' doit être remonté 

Feature: Election

@pourcentageParCandidat
Scenario: Calcul du pourcentage du scrutin pour chaque candidat
Given le tour numéro 1
And le candidat Premier avec 75 votes
And le candidat Deuxième avec 25 votes
When le pourcentage de votes est calculé
Then le candidat Premier a 75% votes
And le candidat Deuxième a 25% votes

@calculScrutin
Scenario: Gagner le scrutin si plus de 50% des votes
Given un scrutin clôturé
And le tour numéro 1
And le candidat Premier avec 51 votes
And le candidat Deuxième avec 49 votes
When le vainqueur du scrutin est déterminé
Then le message 'Premier est le vainqueur.' est affiché


Scenario: Pas de vainqueur au premier tour
Given un scrutin clôturé
And le tour numéro 1
And le candidat Premier avec 40 votes
And le candidat Deuxième avec 35 votes
And le candidat Troisième avec 25 votes
When le vainqueur du scrutin est déterminé
Then le message 'Les candidats Premier et Deuxième passent au deuxième tour.' est affiché

Scenario: Erreur si tour de scrutin supérieur à 2 
Given le tour numéro 3 
Then le message 'Maximum deux tours de scrutin' est affiché

Scenario: Garder les deux meilleurs candidats si moins de 50% des votes
Given un scrutin clôturé
And le tour numéro 1
And le candidat Premier avec 50 votes
And le candidat Deuxième avec 49 votes
And le candidat Troisième avec 25 votes
When le vainqueur du scrutin est déterminé
Then le message 'Les candidats Premier et Deuxième passent au deuxième tour.' est affiché

Scenario: Victoire à majorité au second tour
Given un scrutin clôturé
And le tour numéro 2
And le candidat Premier avec 51 votes
And le candidat Deuxième avec 49 votes
When le vainqueur du scrutin est déterminé
Then le message 'Premier est le vainqueur.' est affiché

Scenario: Égalité au second tour
Given un scrutin clôturé
And le tour numéro 2
And le candidat Premier avec 50 votes
And le candidat Deuxième avec 50 votes
When le vainqueur du scrutin est déterminé
Then le message 'Aucun vainqueur pour ce tour.' est affiché 

Scenario: Erreur lors du calcul du vainqueur lorsque le scrutin n'est pas clôturé
Given un scrutin non clôturé
When le vainqueur du scrutin est déterminé
Then le message 'Le scrutin n'est pas clôturé.' est affiché 

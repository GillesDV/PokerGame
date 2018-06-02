# PokerGame

(First we design the basics for a card game. You can assume this would be code that might be reused for different types of games))

 

-> Can you write and design a Card- and Deck-class

-> Write the code to initialize the deck with all necessary cards.

-> Write the code to deal a specified number of cards.

-> How can we reset the deck after dealing cards?

-> Write the code to shuffle the deck.

 

(The next few lines are a bit more specific to poker, so we assume you know the basics)

 

-> Now extend our domain model with players that can be dealt cards.

-> Allow for a table to be dealt cards.

-> Implement a very simplistic gameflow (start game > shuffle deck > foreach player deal 2 cards > deal 5 cards to table > evaluate hands) (IMPORTANT: You do not need to implement betting)

-> Implement a system to determine the winning player/hand. You do not need to be able to interpret all types of hands, we are happy if your system can interpret a full house, a straight, and a flush. Everything else can be considered a high card. But do take into account that multiple players can have the same type of hand with differing values.

 

We expect a minimal viable product where a number of players get dealt cards and the system decides who wins, this can be a simple console app.

This doesn’t need to be fully fledged with rich features, we basically just want to see how you would design the domain model, how you would implement the functionalities, and what coding style you wield.
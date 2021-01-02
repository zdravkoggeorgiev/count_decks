Task:
 Input is an array with N number of cards. Cards are represented by string with 2 characters, e.g. "AH" is Ace of Hearts, "2D" is 2 of Diamonds, "1C" is 10 of Clubs.
 A method should accept an array as input and to return the count of full decks found.

Solution:
 It took me about 1 hour to create solution with tests. The focus was on performance, so I use a dictionary to save count of each unique card type. After input is processed, I look for the lesser number - that's the count of full decks.
 Initial version was an array int[suits * colors], but I realized it's slow for big arrays, so I switched to use a dictionary, whish uses internally HashSet, and is much faster and indexing.
 I also added global counter - how many items was processed, and a read capability for the each type of card.
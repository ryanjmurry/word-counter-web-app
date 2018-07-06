# Word Counter

#### Epicodus C# Code Review 1, 06.29.2018

#### By Ryan Murry

## Description

A program that checks how frequently a word appears in a given string.

## Specs

| Behavior | Input | Output | Reasoning |
|----------|-------|--------|-----------|
| Gets and sets the **target word** | can | **target word** = can | all letters lowercase and no special characters |
| Checks if the **target word** contains only numbers, letters, and/or single quotes | 1. can </br> 2. c@n </br> 3. can't | 1. **true** </br> 2. **false** </br> 3. **true** | 1. all lowercase with no punctuation at all </br> 2. all lowercase with exempt punctuation </br> 3. all lowercase with allowed punctuation |
| Convert **target word** to lowercase | CAN | **target word** = can | all letters uppercase with no exempt punctuation |
| Gets and sets the **search phrase** | i can swim! | **search phrase** = i can swim! | smallest lowercase sentence including the **target word** |
| Converts **search phrase** to lower case | I CAN SWIM! | **search phrase** = i can swim! | smallest uppercase sentence including the **target word** |
| Takes **search phrase** and stores each word into a **search list** | i can swim | **search list** = { i, can, swim! } | smallest lowercase sentence including the **target word** |
| Removes any trailing and proceeding punctuation marks from each word in the list | { i, 'can', swim! } | **i** = i </br> **'can'** = can </br> **swim!** = swim | smallest lowercase sentence with both proceeding and trailing punctuation marks |
| Replaces the original word in the **search list** with the **clean word** | { i, 'can', swim! } | { i, can, swim } | list of words containing all lowercase letters with both proceeding and trailing punctuation marks |
| Compare **target word** to each **clean word** in the **search list** | **target word** = can </br> **search list** {i, can, swim} | can vs. i = **false** </br> can vs. can = **true** </br> can vs. swim = **false** | a lowercase **target word** with no punctuation compared to a list of lowercase words containing no punctuation whatsoever |
| Return number of matching words | **target word** = can </br> **search list** {i, can, swim} | 1 | single match, no punctuation, all lowercase |

## Known Bugs

### On master Branch
* Not able to handle edge case scenarios, such as when a word is wrapped in parentheses or if the word is followed by a period or comma

### On cleaner-attempt Branch
* No known bugs at this time. Waiting to merge cleaner-attempt to master until after project's code review.


## Setup on OSX

* Download and install .Net Core 1.1.4
* Download and install Mono
* Clone cleaner-attempt repo
* Run `dotnet restore` from within the project directory

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 1.1.4

## Links

* [Link to Repository](https://github.com/ryanjmurry/WordCounter.Solution)

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Ryan Murry**

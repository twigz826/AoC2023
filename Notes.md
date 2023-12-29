## Miscellaneous notes

### Day 3
#### Part 2
- Loop through each line, we only care if there is an asterisk
- Save index of all asterisks in the current line
- Get all numbers and their indexes from all surrounding lines
- Loop through all numbers, filter for touching the asterisk index, add to matches list
- If matches == 2, product of the numbers gets added to the total

module ProjectEuler.Solutions.Common.Text

let private alphabeticPosition (c: char) = int c - int '@' // '@' is the first char before 'A'.

let wordScore (word: string) = Seq.sumBy alphabeticPosition word

# prettier.json

A tiny CLI tool for formatting JSON files to make them easier to read.  
Made because I was bored.

YAML support maybe coming. Eventually. Probably.

---

## Features (for now)

- JSON file formatting (of course)
- Save formatted output to a new file with `--out`
- Stdin support.
- Colorized success/error messages
- Written in C#

---

## Usage

### Format a JSON file and print it to the console:
```bash
prettierjson format file.json [--out]

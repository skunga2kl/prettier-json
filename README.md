# prettier.json

### this project is going stable, so no more big features anymore. only new stuff will be bugfixes and YAML support if i feel like it.
### also im starting a new, fairly big project im making in rust, so look out for that.

A tiny CLI tool for formatting JSON files to make them easier to read.  
Made because I was bored.

YAML support probably not coming.

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

# prettier.json

### this project is basically stable now. no big features coming anymore, just bugfixes and maybe YAML support if i feel like it.
### also, i’m starting a new cargo-helper-ish Rust project soon, so keep an eye out.

A tiny CLI tool for formatting JSON files to make them easier to read.  
Made because I was bored.

YAML support coming at maybe some point or something i dont really knowwwwwww

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

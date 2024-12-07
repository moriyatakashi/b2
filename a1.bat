csc -target:library -out:b1.dll a1.cs
python -c "import js2py;js2py.translate_file('a1.js','b1.py')"
python -B -m a1
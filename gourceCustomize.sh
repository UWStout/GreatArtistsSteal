# Setup Project Name
projName="Great Artists Steal - Source Code"

# Replace non human readable names with proper ones
sed -i -- 's/berriers@uwstout.edu/Seth Berrier/g' gourceLog.txt
sed -i -- 's/noahwus@gmail.com/Noah Wussow/g' gourceLog.txt
sed -i -- 's/deloa6133@my.uwstout.edu/Adam Delo/g' gourceLog.txt
sed -i -- 's/36006013+deloa6133@users.noreply.github.com/Adam Delo/g' gourceLog.txt
sed -i -- 's/garya2365@my.uwstout.edu/Aaron Gary/g' gourceLog.txt

# Clean up the temporary files from sed
rm gourceLog.txt--

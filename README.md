# Cognition.ModulePacker
Simple command line tool to pack music modules (e.g. ProTracker, FastTracker) into JavaScript for easy replaying

###Current issues or unhandled situations (this is a quick tool, I may fix these.. one day :))
 * The auto-generated JavaScript module variable relies on your module filename being compatible as a JavaScript variable name. (If not, you'll need to tweak the name manually in the output
 JS file.. Yes, I know this is rubbish and I will fix it.)
 * No error checking at all yet!

###Possible future enhancements (if I have the need, time or motivation to do them)
 * Allow an output filename to be specified as a command line parameter
 * Add ability to unpack modules back into their original binary module files

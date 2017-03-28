# Tayn Tree Carving Helper

Works with MUDLet

Keeps a DB of Moonhart Elder totems (including their room number for fast-walking to the tree), and their expected time of reverting back to regular trees.

Times for reverting is truncated to the RL-Day (12:00 AM, Midnight) to help account for imperfections in the reporting of times when you PROBE a totem and the weirdness of the Lusternian Calendar.

If you try to carve a totem in a room without a tracked tree, it will automatically add it and update the time.

Otherwise it will update the tracked instance in the DB with the new reversion time (again truncated to midnight, and with the ~258 days added to it).

Listing the available trees will list Totems who are due to expire sometime in the next 24 hours (Lusternian days).


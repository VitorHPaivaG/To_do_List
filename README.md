Notes to myself: Only do a thing per time, dont do 500 things at the same time

Things that are working for now
 * username and check if its empty or not (give a default name if user dont insert anything) (done)
 * make the current/completed/removed lists (done)
 * func. to ask the user to add a new task to the current one (done)
 * func. to ask if the user wants to see the current task list (done)
 * func. to ask if the user wants to remove a task (done)
 * func. to ask what the user wants to do (done)
 * make the tolower comparative in the userchoose == "E", instead of doing == "E" || == "e" (done, by doing a better approach than this one)
 * the same as above, but for doing the todolist.count == 0 or null, i think i can use the string.IsNullOrEmpty? not necessarily the string one, but maybe int? (not exactly done, but, i think the current approach is the best one for now.)
 * ask if the user wants to mark as completed any task on the current task list, remove it of current list to add to completed one (done)

Things that needs to be done:
- how to deal with the removevaluebyindex and do a try catch if its beyond the scope
 
Things that i should reconsider:
 * change the default user_name
 * an better way of repeating the userchoose?
 * using tryparse to do the comparatives, instead of using a bunch of else {} statements

Things to think about, but not really doing?
 * make the user password input private, while typing it on the console

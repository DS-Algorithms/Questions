using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public string SimplifyPath(string path)
    {
        if (path.Length == 1)
            return path;

        int left = 0;

        var stack = new Stack<string>();
        /*
        0 1 2 
        / / a /./b/../../c/
        ^ 
        */
        for (int right = 1; right <= path.Length; right++)
        {
            string dir = "";
            if (right == path.Length || path[right] == '/')
            {
                dir = path.Substring(left + 1, (right - left - 1));
                if (dir == ".." && stack.Count > 0)
                {
                    var pop = stack.Pop();
                    // Console.WriteLine($"poping: {pop}");
                }
                if (dir.Length > 0 && dir != "." && dir != "..")
                {
                    // Console.WriteLine($"Pushing: {dir}");
                    stack.Push(dir);
                }
                left = right;
            }
        }

        var output = "";
        while (stack.Count > 0)
        {
            if (output == "")
                output = stack.Pop();
            else
                output = stack.Pop() + "/" + output;
        }
        output = "/" + output;

        return output;
    }
}

/*
REad until a /
if it is . ignore
if it is .. and stack not empty pop
else push to stack

/home//foo/
      ^
          ^


foo
home

/home/foo

2.

0 1 2 
/ a /./b/../../c/
^ 
          ^


c
if(path.Lenght == 1)
  return path

left = 0

stack = new Stack<string>()

 for(int rightiright=1; right< path.Length; right++)
   if(path[right] == '/'){
     var dir = Substring(path,left+1,(right-left-1))
     if(dir == "..")
         stack.Pop()
     }
     if(dir.Length > 0 and dir != ".")
        stack.push(dir)
    left = right
    
  var output = ""
  while stack.Count > 0
    if(output == "")
        output = stack.Pop()
    else
        output = stack.Pop() + "/" + output
    
 output = "/" + output
 
 return output
        

  
*/

public class Test
{
    public static void Main()
    {
        //case 1
        {
            var path = "/home/";
            var expected = "/home";
            var sol = new Solution();
            var actual = sol.SimplifyPath(path);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{expected==actual}");
        }

        //case 2
        {
            var path = "/../";
            var expected = "/";
            var sol = new Solution();
            var actual = sol.SimplifyPath(path);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{expected == actual}");
        }

        //case 3
        {
            var path = "/home//foo/";
            var expected = "/home/foo";
            var sol = new Solution();
            var actual = sol.SimplifyPath(path);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{expected == actual}");
        }

        //case 4
        {
            var path = "/a/./b/../../c/";
            var expected = "/c";
            var sol = new Solution();
            var actual = sol.SimplifyPath(path);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{expected == actual}");
        }
    }
}
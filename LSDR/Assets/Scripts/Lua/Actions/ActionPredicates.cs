using LSDR.Entities.Original;
using MoonSharp.Interpreter;

namespace LSDR.Lua.Actions
{
    public class ActionPredicates
    {
        public static IPredicate Default() { return new GenericPredicate(() => true); }

        public static IPredicate WaitForSeconds(float numSeconds) { return new WaitForSecondsPredicate(numSeconds); }

        public static IPredicate Custom(Closure closure) { return new GenericPredicate(() => closure.Call().Boolean); }

        public static IPredicate WaitForAnimation(TODAnimation animation, int numberOfPlays = 1)
        {
            var resolutionSeconds = animation.Tod.Header.Resolution * (1 / 60f);
            // +3 here because it always ended up being too short -- 3 extra frames seems to be the sweet spot
            var lengthSeconds = (animation.Tod.Header.NumberOfFrames + 3) * resolutionSeconds * numberOfPlays;
            return new WaitForSecondsPredicate(lengthSeconds);
        }
    }
}

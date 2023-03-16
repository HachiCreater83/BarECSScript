
using Unity.Entities;


public class PreviousGameGroup : ComponentSystemGroup { }

[UpdateAfter(typeof(PreviousGameGroup))]
public class GameGroup : ComponentSystemGroup { }

[UpdateAfter(typeof(GameGroup))]
public class PostGameGroup : ComponentSystemGroup { }
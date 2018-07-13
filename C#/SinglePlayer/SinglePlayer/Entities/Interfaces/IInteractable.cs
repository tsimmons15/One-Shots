namespace SinglePlayer.Entities.Interfaces
{
    /// <summary>
    /// <see cref="IInteractable"/> is an <see cref="Entity"/> which can be interacted with, or can interact with other <see cref="Entity"/>s.
    /// </summary>
    interface IInteractable
    {
        /// <summary>
        /// Interface method for handling an <see cref="Entity"/> trying to interact with this IInteractable.
        /// <para>Example commands: look, touch, &lt;emote&gt; commands</para>
        /// </summary>
        /// <param name="command">The command, with arguments, given to the <see cref="IInteractable"/></param>
        void CommandReceived(string command);
        /// <summary>
        /// Interface method for an <see cref="IInteractable"/> trying to interact with something.
        /// <para>For Player-Controlled <see cref="Character"/>s this will probably handle the getting of UserInput</para>
        /// <para>For other Non-Player-Controlled <see cref="Character"/>s this will be one of the methods called by the AI system.</para>
        /// </summary>
        /// <returns>string - the string either received from UserInput, or from AI system</returns>
        string CommandSent();
    }
}

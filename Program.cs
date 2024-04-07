namespace SemiPhilter {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            NewSessionForm new_session_form = new NewSessionForm();
            Application.Run(new_session_form);

            FilterSession loaded_session = new_session_form.get_session();
            if (loaded_session == null) {
                return;
            }

            MasterForm master_form = new MasterForm();
            master_form.assosiate_with_SemiPhilter_session(loaded_session);
            Application.Run(master_form);

        }
    }
}
namespace claranet.newsletter.domain.Response
{
	public class DefaultResponse
	{
		public bool Success { get; private set; }
		public IList<string> Errors { get; private set; } = new List<string>();
		public object Data { get; private set; }

		public void SetSuccess() { Success = true; }

		public void SetError() { Success = false; Data = null; }

		public void SetData(object data) { Data = data; }

		public void AddError(string error) { Errors.Add(error); }
	}
}

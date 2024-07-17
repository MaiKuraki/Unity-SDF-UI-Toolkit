/***
* This codis adapteanmodifiefrom
* https://github.com/kirevdokimov/Unity-UI-Rounded-Corners/blob/master/UiRoundedCorners/ImageWithRoundedCorners.cs
* https://github.com/kirevdokimov/Unity-UI-Rounded-Corners/blob/master/UiRoundedCorners/Editor/ImageWithIndependentRoundedCornersInspector.cs
**/

using UnityEngine;

namespace TLab.UI.SDF
{
	public class SDFQuad : SDFUI
	{
		private static readonly string SHAPE_NAME = "Quad";

		[SerializeField] private bool m_independent = true;

		[SerializeField, Min(0)] private float m_radius = 40;

		[SerializeField, Min(0)] private float m_radiusX = 40;
		[SerializeField, Min(0)] private float m_radiusY = 40;
		[SerializeField, Min(0)] private float m_radiusZ = 40;
		[SerializeField, Min(0)] private float m_radiusW = 40;

		public static readonly int PROP_RADIUSE = Shader.PropertyToID("_Radius");

		public bool independent
		{
			get => m_independent;
			set
			{
				if (m_independent != value)
				{
					m_independent = value;

					Refresh();
				}
			}
		}

		public float radius
		{
			get => m_radius;
			set
			{
				if (m_radius != value)
				{
					m_radius = value;

					Refresh();
				}
			}
		}

		public float radiusX
		{
			get => m_radiusX;
			set
			{
				if (m_radiusX != value)
				{
					m_radiusX = value;

					Refresh();
				}
			}
		}

		public float radiusY
		{
			get => m_radiusY;
			set
			{
				if (m_radiusY != value)
				{
					m_radiusY = value;

					Refresh();
				}
			}
		}

		public float radiusZ
		{
			get => m_radiusZ;
			set
			{
				if (m_radiusZ != value)
				{
					m_radiusZ = value;

					Refresh();
				}
			}
		}

		public float radiusW
		{
			get => m_radiusW;
			set
			{
				if (m_radiusW != value)
				{
					m_radiusW = value;

					Refresh();
				}
			}
		}

#if UNITY_EDITOR
		protected override void OnValidate()
		{
			base.OnValidate();

			Validate(SHAPE_NAME);
			Refresh();
		}
#endif

		protected override void OnEnable()
		{
			base.OnEnable();

			Validate(SHAPE_NAME);
			Refresh();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		protected override void Refresh()
		{
			base.Refresh();

			var halfRect = ((RectTransform)transform).rect.size * .5f;

			var corners = m_independent ? new Vector4(m_radiusX, m_radiusY, m_radiusZ, m_radiusW) : Vector4.one * m_radius;

			var shortest = halfRect.x < halfRect.y ? halfRect.x : halfRect.y;
			if (corners.x > shortest)
			{
				corners.x = shortest;
			}
			if (corners.y > shortest)
			{
				corners.y = shortest;
			}
			if (corners.z > shortest)
			{
				corners.z = shortest;
			}
			if (corners.w > shortest)
			{
				corners.w = shortest;
			}

			material.SetVector(PROP_RADIUSE, corners);
		}
	}
}

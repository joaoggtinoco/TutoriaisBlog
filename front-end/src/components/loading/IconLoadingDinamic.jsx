import { Spinner } from 'phosphor-react'


export function IconLoadingDinamic({size}) {
  return (
    <Spinner color="#000" weight="duotone" size={size}>
      <animate
        attributeName="opacity"
        values="0;1;0"
        dur="3s"
        repeatCount="indefinite"
      ></animate>
      <animateTransform
        attributeName="transform"
        attributeType="XML"
        type="rotate"
        dur="3s"
        from="0 0 0"
        to="360 0 0"
        repeatCount="indefinite"
      ></animateTransform>
    </Spinner>
  )
}

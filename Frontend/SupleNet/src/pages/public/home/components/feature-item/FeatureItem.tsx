import { Link } from "react-router";

interface FeatureItem {
  image: string;
  name: string;
  path: string;
}

export function FeatureItem({ image, name, path }: FeatureItem) {
  return (
    <Link
      to={path}
      className="flex flex-col gap-2 relative rounded-2xl overflow-hidden hover:-translate-y-3 transition-transform duration-300"
    >
      <div className="relative w-full h-full group ">
        <img
          className=""
          src={image}
          alt={name}
        />
        <div className="w-full h-full absolute top-0 left-0 opacity-40 bg-gradient-to-t from-black to-transparent pointer-events-none"></div>
        <p className="text-white font-semibold text-lg absolute bottom-0 pl-4 pb-2">
          {name}
        </p>
      </div>
    </Link>
  );
}
